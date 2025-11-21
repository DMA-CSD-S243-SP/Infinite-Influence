using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel;
using System.Text;

namespace WebClientV2.Controllers
{
    public class InfluencerController : Controller
    {

        public InfluencerController()
        {

        }

        // POST: InfluencerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Influencer influencer)
        {
            var jsonData = JsonConvert.SerializeObject(influencer);

            var content = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                new APIClient().PostAsync("influencer", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public IActionResult Index()
        {
            //TODO: Fetch influencers from API
            List<Influencer> result = new List<Influencer>();
        

            return View(result);

           
        }
    }
}
