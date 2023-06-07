using Layer.Business;
using Layer.DataAccess.Concrete;
using Layer.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_NTT_data.Extensions;
using Project_NTT_data.Filters;
using Project_NTT_data.Models;
using System.Collections.Generic;
using System.Diagnostics;


namespace Project_NTT_data.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DeviceManager _device;
        private readonly ContextDb _contextDb;
        private readonly UserManager _user;
        private readonly LocationManager _location;
        private readonly OrganizationManager _organization;
        private readonly TypesManager _typesManager;
        private readonly IDataProtector _dataProtector;

        public HomeController(ILogger<HomeController> logger, DeviceManager device, ContextDb contextDb, UserManager user, LocationManager location, OrganizationManager organization, TypesManager typesManager, IDataProtectionProvider dataProtection)
        {
            _logger = logger;
            _device = device;
            _contextDb = contextDb;
            _user = user;
            _location = location;
            _organization = organization;
            _typesManager = typesManager;
            _dataProtector = dataProtection.CreateProtector("HomeControl");
        }
        //[ServiceFilter(typeof(CheckWhiteList))] //eger listedeki ip'lerin disinda bir istek olursa yalnizca index sayfasina erisilemeyecek
        public IActionResult Index()
        {
            DeviceViewModelList modelList = new DeviceViewModelList();
            int? userID=null;
            bool isAdmin = true;
            var u = HttpContext.Session.GetObject<Users>("User");
            var timelimitedprotector = _dataProtector.ToTimeLimitedDataProtector();
            if (u == null)
            {
                var user = _user.GetAdmin();
                HttpContext.Session.SetObject("User", user);
            }
            else
            {
                var sessionObj = HttpContext.Session.GetObject<Users>("User");
                userID = sessionObj.IsAdmin?null: sessionObj.Id;
                isAdmin = sessionObj.IsAdmin;

            }
            var devices = _device.GettAll();
            devices.ForEach(d =>
            {
                d.CryptedID = _dataProtector.Protect(d.Id.ToString());
            });
            var locations = _location.GettAll();
            locations.ForEach(l =>
            {
                l.CrypetedID = timelimitedprotector.Protect(l.Id.ToString(), TimeSpan.FromSeconds(10)); //Temporary crypted ID for 10 seconds
            });
            var organizations = _organization.GettAll();
            var types = _typesManager.GettAll();
            var users = _user.GettAll();
            var list = (from d in devices
                        join l in locations on d.LocationId equals l.Id
                        join o in organizations on d.OrganizationId equals o.Id
                        join t in types on d.TypesId equals t.Id
                        join us in users on o.Id equals us.OrganizationId
                        where (userID==null || us.Id==userID)
                        select new DeviceViewModel
                        {
                            Device_Name = d.Device_Name,
                            IsActive = d.IsActive,
                            LocationId = d.CryptedID,
                            Loc_Name = l.Loc_Name,
                            OrganizationId = d.OrganizationId,
                            OrganizationName = o.Org_Name,
                            TypeName = t.Type_Name,
                            TypesId = d.TypesId,
                            DeviceId = d.CryptedID
                        }).ToList();
            modelList.DeviceList = list;
            modelList.IsAdmin = isAdmin;
            modelList.Location = locations;
            modelList.Organization = organizations;
            modelList.Types = types;
            return View(modelList);
        }
        public IActionResult Delete(int id)
        {
            _device.DeleteDevice(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            int decryptedID = int.Parse(_dataProtector.Unprotect(id));
            Devices dv = _device.FindDevice(decryptedID);
            dv.CryptedID = id;
            SetListItems();

            return View(dv);
        }
        [HttpPost]
        public IActionResult Update(Devices p)
        {
            int decryptedID = int.Parse(_dataProtector.Unprotect(p.CryptedID));
            p.Id = decryptedID;
            _device.updateDevice(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult newdevice()
        {
            SetListItems();

            return View();
        }
        [HttpPost]
        public IActionResult newdevice(Devices p)
        {
            _device.AddDevice(p);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ChangeUser()
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");

            if (sessionObj.IsAdmin)
            {
                var user = _user.GetUser();
                HttpContext.Session.Remove("User");
                HttpContext.Session.SetObject("User", user);
            }
            else
            {
                var user = _user.GetAdmin();
                HttpContext.Session.Remove("User");
                HttpContext.Session.SetObject("User", user);
            }


            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void SetListItems()
        {
            var locationList = _location.GettAll();
            var organizationList = _organization.GettAll();
            var typeList = _typesManager.GettAll();

            List<SelectListItem> locations = (from x in locationList select new SelectListItem { Text = x.Loc_Name, Value = x.Id.ToString() }).ToList();
            ViewBag.locations = locations;

            List<SelectListItem> organizations = (from x in organizationList select new SelectListItem { Text = x.Org_Name, Value = x.Id.ToString() }).ToList();
            ViewBag.organizations = organizations;

            List<SelectListItem> types = (from x in typeList select new SelectListItem { Text = x.Type_Name, Value = x.Id.ToString() }).ToList();
            ViewBag.types = types;
        }

    }
}