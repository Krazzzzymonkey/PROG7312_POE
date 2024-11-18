using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        

        // Shared data structures
        private readonly BinarySearchTree<IssueReport> bst;
        private readonly AVLTree<IssueReport> avlTree;
        private readonly RedBlackTree<IssueReport> redBlackTree;
        private readonly Func<int> generateNextId; // Delegate for ID generation

        public ReportIssuesForm(
            BinarySearchTree<IssueReport> bst,
            AVLTree<IssueReport> avlTree,
            RedBlackTree<IssueReport> redBlackTree,
            Func<int> generateNextId
        )
        {
            InitializeComponent();
          

            // Populate category dropdown
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Pothole");
            cboCategory.Items.Add("Water Issue");
            cboCategory.Items.Add("Electricity");
            cboCategory.Items.Add("Other");

            // Initialize shared data structures
            this.bst = bst;
            this.avlTree = avlTree;
            this.redBlackTree = redBlackTree;
            this.generateNextId = generateNextId;

            btnUploadAttachment.Text = "Upload Attachment";
            btnSubmit.Text = "Submit";
            lstAttachments.Items.Clear();
        }

        public static List<IssueReport> issueReports = new List<IssueReport>();

        private void btnUploadAttachment_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image Files|*.jpg;*.jpeg;*.png|Document Files|*.pdf;*.docx"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    lstAttachments.Items.Add(file);
                }
            }
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            errorProvider.Clear();

            // Validate inputs
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                errorProvider.SetError(txtLocation, "Location is required.");
                isValid = false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider.SetError(cboCategory, "Category is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider.SetError(txtDescription, "Description is required.");
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            // Create new report
            IssueReport newReport = new IssueReport
            {
                Id = generateNextId(), // Use the delegate to generate the next ID
                Description = txtDescription.Text,
                Category = cboCategory.SelectedItem.ToString(),
                Location = txtLocation.Text,
                Attachments = lstAttachments.Items.Cast<string>().ToList(),
                Status = "Pending",
                DateSubmitted = DateTime.Now,
            };

            // Add the new report to shared structures
            issueReports.Add(newReport);
            bst.Insert(newReport);
            avlTree.Insert(newReport);
            redBlackTree.Insert(newReport);

            // Show confirmation
            ToastNotification.Show("Issue Reported Successfully");

            using (var confirmationDialog = new ConfirmationDialogForm("Issue reported successfully!", "Confirmation"))
            {
                confirmationDialog.ShowDialog(this);
            }

            // Clear form for the next report
            txtDescription.Clear();
            cboCategory.SelectedIndex = -1;
            txtLocation.Clear();
            lstAttachments.Items.Clear();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
