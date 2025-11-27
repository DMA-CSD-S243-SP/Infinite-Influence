using System.Runtime.CompilerServices;

namespace WinformsApp
{
    partial class EditAnnouncementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitel = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtdescription = new TextBox();
            lbl4 = new Label();
            txtCreationDate = new TextBox();
            label4 = new Label();
            txtBannerUrl = new TextBox();
            checkStatus = new CheckBox();
            checkVisibility = new CheckBox();
            label3 = new Label();
            txtStateDate = new TextBox();
            label5 = new Label();
            txtEndDate = new TextBox();
            label6 = new Label();
            txtCompanyId = new TextBox();
            label7 = new Label();
            txtFollowers = new TextBox();
            label8 = new Label();
            txtAplicants = new TextBox();
            SuspendLayout();
            // 
            // txtTitel
            // 
            txtTitel.Location = new Point(114, 66);
            txtTitel.Name = "txtTitel";
            txtTitel.ReadOnly = true;
            txtTitel.Size = new Size(283, 31);
            txtTitel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 41);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 1;
            label1.Text = "Titel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(119, 100);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 3;
            label2.Text = "Description";
            // 
            // txtdescription
            // 
            txtdescription.Location = new Point(114, 125);
            txtdescription.Multiline = true;
            txtdescription.Name = "txtdescription";
            txtdescription.ReadOnly = true;
            txtdescription.Size = new Size(283, 31);
            txtdescription.TabIndex = 2;
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.Location = new Point(119, 291);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(120, 25);
            lbl4.TabIndex = 7;
            lbl4.Text = "Creation Date";
            // 
            // txtCreationDate
            // 
            txtCreationDate.Location = new Point(114, 316);
            txtCreationDate.Name = "txtCreationDate";
            txtCreationDate.ReadOnly = true;
            txtCreationDate.Size = new Size(186, 31);
            txtCreationDate.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(119, 159);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 5;
            label4.Text = "BannerUrl";
            // 
            // txtBannerUrl
            // 
            txtBannerUrl.Location = new Point(114, 184);
            txtBannerUrl.Name = "txtBannerUrl";
            txtBannerUrl.ReadOnly = true;
            txtBannerUrl.Size = new Size(283, 31);
            txtBannerUrl.TabIndex = 4;
            // 
            // checkStatus
            // 
            checkStatus.AutoCheck = false;
            checkStatus.AutoSize = true;
            checkStatus.Location = new Point(114, 221);
            checkStatus.Name = "checkStatus";
            checkStatus.Size = new Size(123, 29);
            checkStatus.TabIndex = 8;
            checkStatus.Text = "StatusType";
            checkStatus.UseVisualStyleBackColor = true;
            // 
            // checkVisibility
            // 
            checkVisibility.AutoCheck = false;
            checkVisibility.AutoSize = true;
            checkVisibility.Location = new Point(114, 256);
            checkVisibility.Name = "checkVisibility";
            checkVisibility.Size = new Size(103, 29);
            checkVisibility.TabIndex = 9;
            checkVisibility.Text = "Visibility";
            checkVisibility.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(119, 350);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 11;
            label3.Text = "Start Date";
            // 
            // txtStateDate
            // 
            txtStateDate.Location = new Point(114, 375);
            txtStateDate.Name = "txtStateDate";
            txtStateDate.ReadOnly = true;
            txtStateDate.Size = new Size(186, 31);
            txtStateDate.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(119, 409);
            label5.Name = "label5";
            label5.Size = new Size(84, 25);
            label5.TabIndex = 13;
            label5.Text = "End Date";
            // 
            // txtEndDate
            // 
            txtEndDate.Location = new Point(114, 434);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ReadOnly = true;
            txtEndDate.Size = new Size(186, 31);
            txtEndDate.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(452, 409);
            label6.Name = "label6";
            label6.Size = new Size(105, 25);
            label6.TabIndex = 19;
            label6.Text = "CompanyId";
            // 
            // txtCompanyId
            // 
            txtCompanyId.Location = new Point(447, 434);
            txtCompanyId.Name = "txtCompanyId";
            txtCompanyId.ReadOnly = true;
            txtCompanyId.Size = new Size(168, 31);
            txtCompanyId.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(452, 350);
            label7.Name = "label7";
            label7.Size = new Size(162, 25);
            label7.TabIndex = 17;
            label7.Text = "Required Followers";
            // 
            // txtFollowers
            // 
            txtFollowers.Location = new Point(447, 375);
            txtFollowers.Name = "txtFollowers";
            txtFollowers.ReadOnly = true;
            txtFollowers.Size = new Size(168, 31);
            txtFollowers.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(452, 291);
            label8.Name = "label8";
            label8.Size = new Size(163, 25);
            label8.TabIndex = 15;
            label8.Text = "MaximumAplicants";
            // 
            // txtAplicants
            // 
            txtAplicants.Location = new Point(447, 316);
            txtAplicants.Name = "txtAplicants";
            txtAplicants.ReadOnly = true;
            txtAplicants.Size = new Size(168, 31);
            txtAplicants.TabIndex = 14;
            // 
            // EditAnnouncementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 575);
            Controls.Add(label6);
            Controls.Add(txtCompanyId);
            Controls.Add(label7);
            Controls.Add(txtFollowers);
            Controls.Add(label8);
            Controls.Add(txtAplicants);
            Controls.Add(label5);
            Controls.Add(txtEndDate);
            Controls.Add(label3);
            Controls.Add(txtStateDate);
            Controls.Add(checkVisibility);
            Controls.Add(checkStatus);
            Controls.Add(lbl4);
            Controls.Add(txtCreationDate);
            Controls.Add(label4);
            Controls.Add(txtBannerUrl);
            Controls.Add(label2);
            Controls.Add(txtdescription);
            Controls.Add(label1);
            Controls.Add(txtTitel);
            Name = "EditAnnouncementForm";
            Text = "Edit Menu";
            Load += EditAnnouncementForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitel;
        private Label label1;
        private Label label2;
        private TextBox txtdescription;
        private Label lbl4;
        private TextBox txtCreationDate;
        private Label label4;
        private TextBox txtBannerUrl;
        private CheckBox checkStatus;
        private CheckBox checkVisibility;
        private Label label3;
        private TextBox txtStateDate;
        private Label label5;
        private TextBox txtEndDate;
        private Label label6;
        private TextBox txtCompanyId;
        private Label label7;
        private TextBox txtFollowers;
        private Label label8;
        private TextBox txtAplicants;

        
        
    }

}