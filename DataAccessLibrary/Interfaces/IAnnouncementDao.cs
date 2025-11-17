using DataAccessLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Interfaces;

/// <summary>
/// 
/// </summary>
/// 12-11-2025 11:45 - Anders
public interface IAnnouncementDao
{
    int CreateAnnouncement(Announcement Announcement);

    Announcement GetAnnouncement(int id);

    IEnumerable<Announcement> GetAllAnnouncements();
}


