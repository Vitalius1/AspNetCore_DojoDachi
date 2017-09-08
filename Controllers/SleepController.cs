using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

 
namespace DojoDachi.Controllers
{
    public class SleepController : Controller
    {
        [HttpGet]
        [Route("sleep")]
        public JsonResult SleepMethod()
        {
            DachiPet Edit = HttpContext.Session.GetObjectFromJson<DachiPet>("Pet");
            int energy1 = Edit.energy;
            int fullness1 = Edit.fullness;
            int happiness1 = Edit.happiness;
            Edit.Sleep();
            if (Edit.energy > 99 && Edit.fullness > 99 && Edit.happiness > 99)
            {
                var win = new 
                {
                    pet = Edit,
                    message = "Congratulations! You won!",
                    status = "win",
                    img = "win"
                };
                return Json(win);
            }
            if (Edit.fullness < 1 || Edit.happiness < 1)
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
            int fullness_dif = Edit.fullness - fullness1;
            int happiness_dif = Edit.happiness - happiness1;
            string msg = "Your pet slept! Energy +" + energy_dif + ", Happiness " + happiness_dif + ", Fullness " + fullness_dif;
            HttpContext.Session.SetObjectAsJson("Pet", Edit);
            var res = new 
            {
                pet = Edit,
                message = msg,
                img = "sleep"
            };
            return Json(res);
        }
    }
}
