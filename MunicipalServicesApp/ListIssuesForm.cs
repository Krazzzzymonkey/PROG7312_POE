using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ListIssuesForm : Form
    {
        private ListView lvIssues;
        private Button btnBack;

        // constructor that accepts the list of issues
        public ListIssuesForm(List<IssueReport> issueReports)
        {
            InitializeComponent(issueReports);
        }

        private void InitializeComponent(List<IssueReport> issueReports)
        {
            this.Text = "List of Issues";
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.BackColor = System.Drawing.Color.FromArgb(32, 34, 37);

            lvIssues = new ListView();
            lvIssues.Dock = DockStyle.Top;
            lvIssues.View = View.Details;
            lvIssues.FullRowSelect = true;
            lvIssues.BackColor = System.Drawing.Color.FromArgb(32, 34, 37);  
            lvIssues.ForeColor = System.Drawing.Color.White;  

            
            lvIssues.Columns.Add("Description", 300);
            lvIssues.Columns.Add("Category", 150);
            lvIssues.Columns.Add("Location", 200);

            // populate ListView with issue data
            foreach (var issue in issueReports)
            {
                ListViewItem item = new ListViewItem(issue.Description);
                item.SubItems.Add(issue.Category);
                item.SubItems.Add(issue.Location);
                lvIssues.Items.Add(item);
            }

            
            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);  
            btnBack.ForeColor = System.Drawing.Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Dock = DockStyle.Bottom;
            btnBack.Height = 40;
            btnBack.Click += BtnBack_Click;

            this.Controls.Add(lvIssues);
            this.Controls.Add(btnBack);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
