using ApiClient;
using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using System.ComponentModel;

namespace WinformsApp
{
    public partial class Form1 : Form
    {
        AnnouncementApiClient _apiClient = new AnnouncementApiClient("https://localhost:7051/");
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAnnouncements();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditAnnonucement();
        }


        private void LoadAnnouncements()
        {
            Announcements.Items.Clear();
            foreach (var announcement in _apiClient.GetAllAnnouncements())
            {
                Announcements.Items.Add(announcement);
                Announcements.DisplayMember = "Title";
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            btnEdit.Enabled = Announcements.SelectedIndex != -1;
        }

        private void EditAnnonucement()
        {
            if (Announcements.SelectedIndex == -1)
                return;

            var selectedIndex = Announcements.SelectedIndex;
            var selectedAnnouncement = (ObjectModel.Announcement)Announcements.SelectedItem;
            _apiClient.GetAnnouncement(selectedAnnouncement.Id);
            
            var EditForm = new EditAnnouncementForm(selectedAnnouncement);
            EditForm.Show();

        }

    }
}
