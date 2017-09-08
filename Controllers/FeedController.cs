using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

 
namespace DojoDachi.Controllers
{
    public class FeedController : Controller
    {
        [HttpGet]
        [Route("feed")]
        public JsonResult FeedMethod()
        {
            DachiPet Edit = HttpContext.Session.GetObjectFromJson<DachiPet>("Pet");
            int meals1 = Edit.meals;
            int fullness1 = Edit.fullness;
            if (Edit.meals < 1)
            {
                var result = new 
                {
                    pet = Edit,
                    message = "You can't feed your pet. No more meals left. Go work!",
                    img = "notlike"
                };
                return Json(result);
            }
            Edit.Feed();
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
            int meals_dif = Edit.meals - meals1;
            int fullness_dif = Edit.fullness - fullness1;
            string msg  = "";
            string img = "";
            if(fullness_dif == 0)
            {
                msg += "You fed your pet but he didn't like it. Meals " + meals_dif;
                img += "nofood";
            }
            else
            {
                msg += "Your pet liked the meal! Meals " + meals_dif + ", Fullness +" + fullness_dif;
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
}
