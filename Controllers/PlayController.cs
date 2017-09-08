using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

 
namespace DojoDachi.Controllers
{
    public class PlayController : Controller
    {
        [HttpGet]
        [Route("play")]
        public JsonResult PlayMethod()
        {
            DachiPet Edit = HttpContext.Session.GetObjectFromJson<DachiPet>("Pet");
            int energy1 = Edit.energy;
            int happiness1 = Edit.happiness;
            Edit.Play();
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
            int happiness_dif = Edit.happiness - happiness1;
            string msg  = "";
            string img = "";
            if(happiness_dif == 0)
            {
                msg += "You played with your pet but he didn't like it. Energy " + energy_dif;
                img += "notlike";
            }
            else
            {
                msg += "Your pet liked playing! Energy " + energy_dif + ", Happiness +" + happiness_dif;
                img += "like";
            }
            HttpContext.Session.SetObjectAsJson("Pet", Edit);
            var res = new 
            {
                pet = Edit,
                message = msg,
                img = img
            };
            return Json(res);
        }

    }
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
