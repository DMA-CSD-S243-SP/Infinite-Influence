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
}
