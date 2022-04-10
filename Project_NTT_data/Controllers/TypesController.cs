using Layer.Business;
using Layer.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Project_NTT_data.Extensions;

namespace Project_NTT_data.Controllers
{
    public class TypesController : Controller
    {
        private readonly TypesManager _types;

        public TypesController(TypesManager types)
        {
            _types = types;
        }

        [HttpGet]
        public IActionResult newTypes()
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
        public IActionResult newTypes(Types p)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _types.AddTypes(p);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                Types types = _types.findTypes(id);
                return View(types);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Update(Types p)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _types.updateTypes(p);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var sessionObj = HttpContext.Session.GetObject<Users>("User");
            if (sessionObj.IsAdmin)
            {
                _types.DeleteTypes(id);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
