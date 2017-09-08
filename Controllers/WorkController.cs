using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

 
namespace DojoDachi.Controllers
{
    public class WorkController : Controller
    {
        [HttpGet]
        [Route("work")]
        public JsonResult WorkMethod()
        {
            DachiPet Edit = HttpContext.Session.GetObjectFromJson<DachiPet>("Pet");
            int energy1 = Edit.energy;
            int meals1 = Edit.meals;
            Edit.Work();
            if (Edit.energy < 1)
            {
                var result = new 
                {
                    pet = Edit,
                    message = "Your Dojodachi has passed away...",
                    status = "gameover",
                    img = "dead"
                };
                return Json(result);
            }
            int energy_dif = Edit.energy - energy1;
            int meals_dif = Edit.meals - meals1;
            string msg = "Your pet worked hard! Energy " + energy_dif + ", Meals +" + meals_dif;
            HttpContext.Session.SetObjectAsJson("Pet", Edit);
            var res = new 
            {
                pet = Edit,
                message = msg,
                img = "like"
            };
            return Json(res);
        }
    }
}