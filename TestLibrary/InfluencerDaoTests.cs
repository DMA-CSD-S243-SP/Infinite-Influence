using DataAccessLibrary;
using DataAccessLibrary.Daoclasser;
using DataAccessLibrary.Interfaces;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary;

public class InfluencerDaoTests
{
    private String connectionString = DataAccessLibrary.DefaultValues.DefaultConnectionString;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateInfluencer()
    {
        //arrange
        IInfluencerDao DAO = new InfluencerDao(connectionString);

        Influencer newInfluencer = new Influencer("testUser", "testpassword", "Testdisplayname", true, "imageUrl", "Denmark", "twitter", 10);
        //act

        int newId = DAO.createInfluencer(newInfluencer);

        //assert

        Assert.That(newId > 0);
    }

    [Test]
    public void JoinAnnouncement()
    {
        //arrange
        IInfluencerDao DAO = new InfluencerDao(connectionString);
        int influencerId = 2; //you have to manually change this id to an existing influencer in the test database that hasnt joined the announcement yet
        int announcementId = 3; //you have to manually change this id to an existing announcement in the test database that the influencer hasnt joined yet
        //act
        bool result = DAO.JoinAnnouncement(influencerId, announcementId);
        //assert
        Assert.That(result == true);
    }
}
