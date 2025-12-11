using DataAccessLibrary;
using DataAccessLibrary.Daoclasser;
using DataAccessLibrary.Interfaces;
using ObjectModel;

namespace TestLibrary;

public class LoginDaoTests
{
    /**
     * Tests currently expect that the user "trendsetter01" with password "Password" exists, and that the user "UsernameThatDoesNotExist" does not.
     */
    [SetUp]
    public void Setup()
    {
    }

    /*
     * 
     */

    [Test]
    public void AttemptLoginShouldReturnUser()
    {
        // Arrange
        string TestUsername = "trendsetter01";
        string TestPassword = "Password";
        /* This code would add the influencer dynamically, but there is no delete method.
        Influencer newInfluencer;
        try
        {
            IInfluencerDao DAO = new InfluencerDao(DefaultValues.DefaultConnectionString);

            newInfluencer = new Influencer(TestUsername, TestPassword, "Testdisplayname", true, "imageUrl", "Denmark", "twitter", 10);

            DAO.createInfluencer(newInfluencer);
        }
        catch (Exception ex)
        {
            // Cancel test, if prerequesites cannot be set up.
            Assert.Inconclusive();
        }*/
        ILoginDao dataAccess = new LoginDAO(DefaultValues.DefaultConnectionString);

        // Act
        ILoginDao.User foundUser = dataAccess.AttemptLogin(TestUsername, TestPassword);

        // Assert
        Assert.IsNotNull(foundUser);
    }

    [Test]
    public void AttemptLoginShouldNotFindUser()
    {
        // Arrange
        string TestUsername = "UsernameThatDoesNotExist";
        string TestPassword = "Password";

        ILoginDao dataAccess = new LoginDAO(DefaultValues.DefaultConnectionString);

        // Assert
        Assert.Throws<DataAccessLibrary.Interfaces.ILoginDao.InvalidLoginException>(() => {
            // Act
            ILoginDao.User foundUser = dataAccess.AttemptLogin(TestUsername, TestPassword);
        });
    }

    [Test]
    public void AttemptLoginShouldGiveInvalidPassword()
    {
        // Arrange
        string TestUsername = "trendsetter01";
        string TestPassword = "NotPassword";

        ILoginDao dataAccess = new LoginDAO(DefaultValues.DefaultConnectionString);

        // Assert
        Assert.Throws<DataAccessLibrary.Interfaces.ILoginDao.InvalidLoginException>(() => {
            // Act
            ILoginDao.User foundUser = dataAccess.AttemptLogin(TestUsername, TestPassword);
        });
    }
}
