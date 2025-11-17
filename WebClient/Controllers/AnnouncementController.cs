using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class AnnouncementController : Controller
    {
        private IAnnouncementDao _announcementDao;

        public AnnouncementController()
        {
            _announcementDao = DataAccessLibrary.DefaultValues.DefaultAnnouncementDao;
        }

        // GET: AnnouncementController
        public ActionResult Index()
        {
            return View(new List<Announcement>());
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
