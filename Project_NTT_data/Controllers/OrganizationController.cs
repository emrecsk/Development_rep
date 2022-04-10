using Layer.Business;
using Layer.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Project_NTT_data.Extensions;

namespace Project_NTT_data.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly OrganizationManager _organization;

        public OrganizationController(OrganizationManager organization)
        {
            _organization = organization;
        }

        [HttpGet]
        public IActionResult neworganization()
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
        public IActionResult neworganization(Organization p)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _organization.AddOrganization(p);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                Organization organization = _organization.findOrganization(id);
            return View(organization);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Update(Organization p)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _organization.updateOrganization(p);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _organization.DeleteOrganization(id);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
