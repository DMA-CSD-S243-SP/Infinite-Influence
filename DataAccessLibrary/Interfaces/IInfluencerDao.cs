using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces;

public interface IInfluencerDao
{

    int createInfluencer(Influencer influencer);

    bool JoinAnnouncement(int influencerId, int announcementId);

}
