using ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsApp
{
    public partial class EditAnnouncementForm : Form
    {
        Announcement _selectedAnnouncement;

        public EditAnnouncementForm(Announcement selectedAnnouncement)
        {
            _selectedAnnouncement = selectedAnnouncement;
            InitializeComponent();
        }

        private void EditAnnouncementForm_Load(object sender, EventArgs e)
        {
            Load_Fields();
        }

        private void Load_Fields()
        {
            txtTitel.Text = _selectedAnnouncement.Title;
            txtdescription.Text = _selectedAnnouncement.Description;
            txtBannerUrl.Text = _selectedAnnouncement.BannerUrl;
            checkStatus.Checked = _selectedAnnouncement.StatusType;
            checkVisibility.Checked = _selectedAnnouncement.VisibilityState;
            txtCreationDate.Text = _selectedAnnouncement.CreationDate.ToString();
            txtStateDate.Text = _selectedAnnouncement.StartDisplayDate.ToString();
            txtEndDate.Text = _selectedAnnouncement.EndDisplayDate.ToString();
            txtAplicants.Text = _selectedAnnouncement.MaximumApplicants.ToString();
            txtFollowers.Text = _selectedAnnouncement.RequiredFollowers.ToString();
            txtCompanyId.Text = _selectedAnnouncement.CompanyId.ToString();
        }
    }
}
