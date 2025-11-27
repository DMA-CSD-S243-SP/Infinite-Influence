using ObjectModel;
using RestSharp;
using System.Net.Http;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ApiClient;

/// <summary>
/// this class manages api calls for announcements. 
/// </summary>
/// 13-11-2025 11:00 - Anders
public class AnnouncementApiClient
{
    //the url for the api server.
    private readonly string _apiUrl = "https://localhost:7099/api/";

    //the restclient to call the server.
    private readonly HttpClient _httpClient;
    public AnnouncementApiClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_apiUrl)
        };
    }

    public int CreateAnnouncement(Announcement Announcement)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Announcement> GetAllAnnouncements()
    {
        try
        {
            var response = _httpClient.GetAsync("Announcement").Result;

            var content = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var announcements = JsonSerializer.Deserialize<IEnumerable<Announcement>>(content);
                return announcements;
            }

            throw new Exception($"Server reply: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            throw new Exception("Error fetching announcements", ex);
        }
    }


    public Announcement? GetAnnouncement(int id)
    {
        /*var request = new RestRequest($"blogposts/{id}", Method.Get);
        var response = _httpClient.Execute<Announcement>(request);

        if (response == null) throw new Exception("NO response from server");

        if (response.IsSuccessStatusCode) return response.Data;

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent) return null;
        throw new Exception("Server reply: Unsuccessful request");*/
        return null;
    }
}
