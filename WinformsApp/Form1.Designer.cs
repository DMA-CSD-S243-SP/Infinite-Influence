namespace WinformsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Announcements = new ListBox();
            splitContainer1 = new SplitContainer();
            btnDelete = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // Announcements
            // 
            Announcements.FormattingEnabled = true;
            Announcements.ItemHeight = 25;
            Announcements.Location = new Point(4, -3);
            Announcements.Name = "Announcements";
            Announcements.Size = new Size(383, 779);
            Announcements.TabIndex = 0;
            Announcements.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(-2, 1);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(Announcements);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnDelete);
            splitContainer1.Panel2.Controls.Add(btnEdit);
            splitContainer1.Size = new Size(1171, 779);
            splitContainer1.SplitterDistance = 390;
            splitContainer1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(416, 537);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(193, 71);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Slet";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(416, 624);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(193, 71);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 776);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Infinite Influence";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox Announcements;
        private SplitContainer splitContainer1;
        private Button btnDelete;
        private Button btnEdit;
    }
}
