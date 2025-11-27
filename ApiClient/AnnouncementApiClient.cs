using DataAccessLibrary.Interfaces;
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
public class AnnouncementApiClient : IAnnouncementDao
{
    //the url for the api server.
    private readonly string _apiUrl = "https://localhost:7051/api/";

    //the restclient to call the server.
    private readonly HttpClient _httpClient;
    public AnnouncementApiClient(string apiUrl)
    {
        _apiUrl = apiUrl;
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
            var response = _httpClient.GetAsync("https://localhost:7051/api/Announcement").Result;

            Console.WriteLine($"Status: {response.StatusCode}");
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine($"Content: {content}");

            if (response.IsSuccessStatusCode)
            {
                var announcements = JsonSerializer.Deserialize<IEnumerable<Announcement>>(content);
                return announcements;
            }

            throw new Exception($"Server reply: {response.StatusCode} - {content}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
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
