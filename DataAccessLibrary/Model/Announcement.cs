namespace DataAccessLibrary.Model;

/// <summary>
/// this class represents a collaboration post, which influencers can apply to.
/// </summary>
/// 12-11-2025 10:45 - Anders
public class Announcement
{
    #region Properties
    public string Title { get; set; }
    public string Description { get; set; }
    public string BannerUrl { get; set; }
    public bool StatusType { get; set; }
    public bool VisibilityState { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime StartDisplayDate { get; set; }
    public DateTime EndDisplayDate { get; set; }
    public int MaximumApplicants { get; set; }
    public int RequiredFollowers { get; set; }
    public int CompanyId { get; set; }

    private Influencer[] _applicants;
    #endregion

       public Announcement(string title, string description, string bannerUrl, bool statusType, bool visibilityState, DateTime postCreationDate, DateTime postStartDate, DateTime postEndDate, int maximumApplicants, int requiredFollowerAmount, int companyId)
    {
        Title = title;
        Description = description;
        BannerUrl = bannerUrl;
        StatusType = statusType;
        VisibilityState = visibilityState;
        CreationDate = postCreationDate;
        StartDisplayDate = postStartDate;
        EndDisplayDate = postEndDate;
        MaximumApplicants = maximumApplicants;
        RequiredFollowers = requiredFollowerAmount;
        CompanyId = companyId;


        _applicants = new Influencer[MaximumApplicants];
    }
}
