using DataAccessLibrary.Daoclasser;
using DataAccessLibrary.Interfaces;

namespace DataAccessLibrary
{
    public static class DefaultValues
    {
        public static string DefaultConnectionString { get { return "Data Source=localhost;Initial Catalog=infiniteInfluence;User ID=sa;Password=@12tf56so;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";  } }

        public static IAnnouncementDao DefaultAnnouncementDao { get { return new AnnouncementDao(DefaultConnectionString); } }

        public static IInfluencerDao DefaultInfluencerDao { get { return new InfluencerDao(DefaultConnectionString); } }
    }
}
