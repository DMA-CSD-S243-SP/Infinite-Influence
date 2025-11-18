using ObjectModel;
using System.ComponentModel.Design;

namespace TestLibrary;

public class AnnouncementWebClientTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AnnouncementControllerInsertIntoDatabase()
    {
        // Arrange
        Announcement announcement = new("Test Announcement", "This is a test", "google.com", true, true, DateTime.Now, DateTime.Now, DateTime.Now, 10, 10, 6);
        WebClientV2.Controllers.AnnouncementController control = new();

        // Act
        control.Create(announcement);

        // Assert
        Assert.Pass();
    }
}
