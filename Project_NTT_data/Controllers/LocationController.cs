using Layer.Business;
using Layer.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Project_NTT_data.Extensions;

namespace Project_NTT_data.Controllers
{
    public class LocationController : Controller
    {
        private readonly LocationManager _location;

        public LocationController(LocationManager location)
        {
            _location = location;
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
        public IActionResult Update(int id)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                Location location = _location.findLocation(id);
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
