using DataAccessLibrary.Daoclasser;
using DataAccessLibrary.Interfaces;
using ObjectModel;

namespace TestLibrary
{
    /// <summary>
    /// test class for AnnouncementDao it will test the connection to the database and methods to manipulate data in the Announcement table.
    /// </summary>
    /// 17-11-2025 10:40 - Anders
    public class Tests
    {

        private String connectionString = DataAccessLibrary.DefaultValues.DefaultConnectionString;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateAnnouncementAndReturnOneTest()
        {
               
            //arrange
            IAnnouncementDao DAO = new AnnouncementDao(connectionString);

            Announcement newAnnouncement = new Announcement("testTitle" , "testdescription", "testUrl", false, false, DateTime.Now, DateTime.Now, DateTime.Now, 10,100, 1);

            //act

            int newId = DAO.CreateAnnouncement(newAnnouncement);

            //assert

            Assert.That(newId > 0);

            var fetchedAnnouncement = DAO.GetAnnouncement(newId);
            Assert.That(fetchedAnnouncement, Is.Not.Null);
            Assert.That(fetchedAnnouncement.Title, Is.EqualTo("testTitle"));

        }

        [Test]
        public void GetAllAnnouncementsTest()
        {
            //arrange
            IAnnouncementDao DAO = new AnnouncementDao(connectionString);

            //act
            var announcements = DAO.GetAllAnnouncements();

            //assert
            Assert.That(announcements, Is.Not.Null);
            Assert.That(announcements.Count() > 4);
        }

    }
}