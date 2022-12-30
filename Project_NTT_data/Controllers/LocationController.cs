using Layer.Business;
using Layer.Entity.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Project_NTT_data.Extensions;

namespace Project_NTT_data.Controllers
{
    public class LocationController : Controller
    {
        private readonly LocationManager _location;
        private readonly IDataProtector _dataProtector;

        public LocationController(LocationManager location, IDataProtectionProvider dataProtection)
        {
            _location = location;
            _dataProtector = dataProtection.CreateProtector("HomeControl"); //This CreateProtector name must be same with the one on home controller
        }

        [HttpGet]
        public IActionResult newlocation()
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult newlocation(Location p)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _location.AddLocation(p);
            }
                return RedirectToAction("Index", "Home");            
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            var timelimited = _dataProtector.ToTimeLimitedDataProtector();

            if (sessionObj.IsAdmin)
            {
                int decrypetedID = int.Parse(timelimited.Unprotect(id));
                Location location = _location.findLocation(decrypetedID);
            return View(location);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Update(Location p)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _location.updateLocation(p);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _location.DeleteLocation(id);
            }
                return RedirectToAction("Index", "Home");            
        }
    }
}
