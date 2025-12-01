using ApiClient;
using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using System.ComponentModel;

namespace WinformsApp
{
    public partial class Form1 : Form
    {
        AnnouncementApiClient _apiClient = new AnnouncementApiClient();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAnnouncement();
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
            btnDelete.Enabled = Announcements.SelectedIndex != -1;
        }

        private void EditAnnonucement()
        {
            if (Announcements.SelectedIndex == -1)
                return;

            var selectedIndex = Announcements.SelectedIndex;
            var selectedAnnouncement = (ObjectModel.Announcement)Announcements.SelectedItem;

            var EditForm = new EditAnnouncementForm(selectedAnnouncement);
            EditForm.Show();
        }
        private void DeleteAnnouncement()
        {
            if (Announcements.SelectedIndex == -1)
                return;

            var selectedAnnouncement = (ObjectModel.Announcement)Announcements.SelectedItem;
            var confirmResult = MessageBox.Show($"Are you sure to delete this announcement: {selectedAnnouncement.Title} ?", "Confirm Delete!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _apiClient.DeleteAnnouncement(selectedAnnouncement.Id);
                    LoadAnnouncements();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting announcement: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
