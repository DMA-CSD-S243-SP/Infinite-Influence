using ObjectModel;

namespace WebClientV2
{
    public class APIClient : HttpClient
    {
        //the url for the api server.
        private static readonly string apiUrl = "https://localhost:7099/api/"; // TODO If moved to remote host, replace url

        public APIClient()
        {
            BaseAddress = new Uri(apiUrl);
        }
    }
}
