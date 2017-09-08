using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

 
namespace DojoDachi.Controllers
{
    public class MainController : Controller
    {
        [HttpGetAttribute]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<DachiPet>("Pet") == null)
            {
                HttpContext.Session.SetObjectAsJson("Pet", new DachiPet());
            }
            ViewBag.D = HttpContext.Session.GetObjectFromJson<DachiPet>("Pet");
            ViewBag.msg = "Congrats!!! You have a new pet.";
            return View("index");
        }

        [HttpGet]
        [Route("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
