using DataAccessLibrary.Daoclasser;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Model;

namespace TestLibrary
{
    /// <summary>
    /// test class for AnnouncementDao it will test the connection to the database and methods to manipulate data in the Announcement table.
    /// </summary>
    public class Tests
    {

        private String connectionString = DataAccessLibrary.DefaultValues.DefaultConnectionString;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateAnnouncementTest()
        {
               
            //arrange
            IAnnouncementDao DAO = new AnnouncementDao(connectionString);

            Announcement newAnnouncement = new Announcement("testTitle" , "testdescription", "testUrl", false, false, DateTime.Now, DateTime.Now, DateTime.Now, 10,100, 1);

            //act

            int newId = DAO.CreateAnnouncement(newAnnouncement);

            //assert

            Assert.That(newId > 0);
        }
    }
}