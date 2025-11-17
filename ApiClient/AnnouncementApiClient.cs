using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Model;
using RestSharp;

namespace ApiClient;

/// <summary>
/// this class manages api calls for announcements. 
/// </summary>
/// 13-11-2025 11:00 - Anders
public class AnnouncementApiClient : IAnnouncementDao
{
    //the url for the api server.
    private readonly string apiUrl;

    //the restclient to call the server.
    private readonly RestClient _restclient;
    public AnnouncementApiClient(string apiUrl)
    {
        this.apiUrl = apiUrl;
        _restclient = new RestClient(apiUrl);
    }

    public int CreateAnnouncement(Announcement Announcement)
    {
        var request = new RestRequest("Announcement", Method.Post);
        request.AddJsonBody(Announcement);

        var response = _restclient.Execute<int>(request);
        if(response == null)
        {
            throw new Exception("No response from server");
        }
        if(!response.IsSuccessStatusCode)
        {             
            throw new Exception("Server Response: unsuccessful request");
        }
        return response.Data;

    }
}
