using DataAccessLibrary;
using DataAccessLibrary.Daoclasser;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using ObjectModel;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        // GET: api/<Announcement>
        [HttpGet]
        public IActionResult Get()
        {
            ContentResult result;

            try
            {
                IEnumerable<Announcement> announcements = DefaultValues.DefaultAnnouncementDao.GetAllAnnouncements();
                string jsonString = JsonConvert.SerializeObject(announcements);
                result = new ContentResult()
                {
                    Content = jsonString,
                    StatusCode = 200,
                };
            }
            catch (Exception ex) 
            {
                result = new ContentResult()
                {
                    Content = ex.Message, // HACK: Passes exception to user. Very useful for developers, very useful for hackers too...
                    StatusCode = 404,
                };
            }
            

            return result;
        }

        // GET api/<Announcement>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ContentResult result;

            try
            {
                Announcement announcement = DefaultValues.DefaultAnnouncementDao.GetAnnouncement(id);
                string jsonString = JsonConvert.SerializeObject(announcement);
                result = new ContentResult()
                {
                    Content = jsonString,
                    StatusCode = 200,
                };
            }
            catch (Exception ex)
            {
                result = new ContentResult()
                {
                    Content = ex.Message, // HACK: Passes exception to user. Very useful for developers, very useful for hackers too...
                    StatusCode = 404,
                };
            }


            return result;
        }

        // POST api/<Announcement>
        [HttpPost]
        public IActionResult Post(string json)
        {
            ContentResult result;

            try
            {
                Announcement? announcement = JsonConvert.DeserializeObject<Announcement>(json);
                DefaultValues.DefaultAnnouncementDao.CreateAnnouncement(announcement);

                result = new ContentResult()
                {
                    Content = "Announcement was created.",
                    StatusCode = 201,
                };
            }
            catch (Exception ex)
            {
                result = new ContentResult()
                {
                    Content = ex.Message, // HACK: Passes exception to user. Very useful for developers, very useful for hackers too...
                    StatusCode = 404,
                };
            }


            return result;
        }

        // PUT api/<Announcement>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return new ContentResult()
            {
                Content = "Not implemented",
                StatusCode = 501
            }; // Not implemented
        }

        // DELETE api/<Announcement>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new ContentResult() 
            {
                Content = "Not implemented",
                StatusCode = 501
            }; // Not implemented
        }
    }
}
