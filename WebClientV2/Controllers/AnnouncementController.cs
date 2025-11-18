using APIV1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel;
using System.Net;
using System.Text;

namespace WebClientV2.Controllers
{
    public class AnnouncementController : Controller
    {
        public AnnouncementController()
        {

        }

        // GET: AnnouncementController
        public ActionResult Index()
        {
            IEnumerable<Announcement> result;
            HttpResponseMessage response = new HttpClient().GetAsync("https://localhost:7051/api/Announcement").Result;
            if (((int)response.StatusCode) == 200)
            {
                result = JsonConvert.DeserializeObject<IEnumerable<Announcement>>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                result = new List<Announcement>();
            }

            return View(result);
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(int id)
        {
            Announcement? result;
            HttpResponseMessage response = new APIClient().GetAsync($"Announcement/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<Announcement>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                result = null;
            }

            return View(result);
        }

        // GET: AnnouncementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnnouncementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Announcement announcement)
        {
            var jsonData = JsonConvert.SerializeObject(announcement);

            var content = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                new APIClient().PostAsync("Announcement", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: AnnouncementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Announcement announcement)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Announcement announcement)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
