using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace DataAccessLibrary.Interfaces;

/// <summary>
/// 
/// </summary>
/// 17-11-2025 10:05 - Anders
public interface IAnnouncementDao
{
    int CreateAnnouncement(Announcement Announcement);

    Announcement GetAnnouncement(int id);

    IEnumerable<Announcement> GetAllAnnouncements();

    bool DeleteAnnouncement(int id);
}


