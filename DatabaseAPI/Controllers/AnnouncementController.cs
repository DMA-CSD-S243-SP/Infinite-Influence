using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAPI.Controllers;


/// <summary>
/// this class manages endpoints for announcements. 
/// </summary>
/// 13-11-2025 10:25 - Anders
[ApiController]
[Route("[controller]")]
public class AnnouncementController : ControllerBase
{
    IAnnouncementDao _announcementDao;

    public AnnouncementController(IAnnouncementDao announcementDao)
    {
        _announcementDao = announcementDao;
    }

    [HttpPost]
    public ActionResult<int> Create(Announcement announcement)
    {
        try
        {
            return Ok(_announcementDao.CreateAnnouncement(announcement));
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while trying to create an Announcement");
        }
    }
}
