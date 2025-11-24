namespace ObjectModel;


/// <summary>
/// Influencer class represents a social media influencer, which can apply to different companies annoucements. 
/// </summary>
/// 20-11-2025 13:00 - Anders
public class Influencer
{

    #region properties
    public int Id { get; set; }
    public String Username { get; set; }
    public String Credentials { get; set; }
    public String DisplayName { get; set; }
    public Boolean VerificationStatus { get; set; }
    public String ProfileImageUrl { get; set; }
    public String Location { get; set; }
    public String MainPlatformUrl { get; set; }
    public int Followers { get; set; }
    #endregion

    public Influencer(){}
    
        
   
    public Influencer(string username, string credentials, string displayName, bool verificationStatus, string profileImageUrl, string location, string mainPlatformUrl, int followers)
    {
        Username = username;
        Credentials = credentials;
        DisplayName = displayName;
        VerificationStatus = verificationStatus;
        ProfileImageUrl = profileImageUrl;
        Location = location;
        MainPlatformUrl = mainPlatformUrl;
        Followers = followers;
    }
}