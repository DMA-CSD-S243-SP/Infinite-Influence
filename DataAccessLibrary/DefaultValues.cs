using DataAccessLibrary.Daoclasser;
using DataAccessLibrary.Interfaces;

namespace DataAccessLibrary
{
    public static class DefaultValues
    {
        public static string DefaultConnectionString { get { return "\"Data Source=localhost;Persist Security Info=True;User ID=sa;Password=@12tf56so;Encrypt=True;Trust Server Certificate=True\"";  } }

        public static IAnnouncementDao DefaultAnnouncementDao { get { return new AnnouncementDao(DefaultConnectionString); } }
    }
}
