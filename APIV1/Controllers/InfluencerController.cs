using DataAccessLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectModel;

namespace APIV1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InfluencerController : ControllerBase
{
    // POST api/<Announcement>
    [HttpPost]
    public IActionResult Post([FromBody] Influencer influencer)
    {
        try
        {
            DefaultValues.DefaultInfluencerDao.createInfluencer(influencer);

            return StatusCode(201, new { message = "Influencer was created." });
        }
        catch (Exception ex)
        {
            return StatusCode(400, new { error = ex.Message });
        }
    }

    // POST api/<Announcement>/Join/{announcementId}
    [HttpPost]
    [Route("Join/{announcementId}")]
    public IActionResult Join([FromBody] int influencerId, int announcementId)
    { 


        try
        {
            DefaultValues.DefaultInfluencerDao.JoinAnnouncement(influencerId, announcementId);

            return StatusCode(201, new { message = "Influencer joined announcement." });
        }
        catch (Exception ex)
        {
            return StatusCode(400, new { error = ex.Message });
        }
    }
}
