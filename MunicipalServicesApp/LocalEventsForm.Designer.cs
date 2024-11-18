using System;

namespace MunicipalServicesApp
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblRecommendation;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblRecommendation = new System.Windows.Forms.Label();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.SuspendLayout();

            // 
            // lblSearch
            // 
            this.lblSearch.Text = "Search Events:";
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Size = new System.Drawing.Size(120, 30);
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.LightGray;

            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(150, 20);
            this.txtSearch.Size = new System.Drawing.Size(300, 30);
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(26, 28, 30);
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // lblCategory
            // 
            this.lblCategory.Text = "Category:";
            this.lblCategory.Location = new System.Drawing.Point(20, 60);
            this.lblCategory.Size = new System.Drawing.Size(120, 30);
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.LightGray;

            // 
            // cboCategory
            // 
            this.cboCategory.Location = new System.Drawing.Point(150, 60);
            this.cboCategory.Size = new System.Drawing.Size(300, 30);
            this.cboCategory.BackColor = System.Drawing.Color.FromArgb(26, 28, 30);
            this.cboCategory.ForeColor = System.Drawing.Color.White;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.Items.AddRange(new string[] { "All", "Sanitation", "Utilities", "Education", "Health", "Technology" });
            this.cboCategory.SelectedIndex = 0;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // lblStartDate
            // 
            this.lblStartDate.Text = "Start Date:";
            this.lblStartDate.Location = new System.Drawing.Point(20, 100);
            this.lblStartDate.Size = new System.Drawing.Size(120, 30);
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.ForeColor = System.Drawing.Color.LightGray;

            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(150, 100);
            this.dtpStartDate.Size = new System.Drawing.Size(300, 30);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // lblEndDate
            // 
            this.lblEndDate.Text = "End Date:";
            this.lblEndDate.Location = new System.Drawing.Point(20, 140);
            this.lblEndDate.Size = new System.Drawing.Size(120, 30);
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEndDate.ForeColor = System.Drawing.Color.LightGray;

            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(150, 140);
            this.dtpEndDate.Size = new System.Drawing.Size(300, 30);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            DateTime firstOfNextMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1);
            dtpEndDate.Value = firstOfNextMonth;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // 
            // btnSearch
            // 
            this.btnSearch.Text = "Search";
            this.btnSearch.Location = new System.Drawing.Point(20, 180);
            this.btnSearch.Size = new System.Drawing.Size(430, 40);
            this.btnSearch.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            // 
            // lstEvents
            // 
            this.lstEvents.Location = new System.Drawing.Point(20, 230);
            this.lstEvents.Size = new System.Drawing.Size(430, 200);
            this.lstEvents.BackColor = System.Drawing.Color.FromArgb(26, 28, 30);
            this.lstEvents.ForeColor = System.Drawing.Color.White;
            this.lstEvents.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // lblRecommendation
            // 
            this.lblRecommendation.Text = "To get recommendations, please search.";
            this.lblRecommendation.Location = new System.Drawing.Point(20, 440);
            this.lblRecommendation.Size = new System.Drawing.Size(430, 30);
            this.lblRecommendation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecommendation.ForeColor = System.Drawing.Color.LightGray;

            // 
            // LocalEventsForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.BackColor = System.Drawing.Color.FromArgb(32, 34, 37);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lblRecommendation);
            this.Text = "Local Events and Announcements";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
