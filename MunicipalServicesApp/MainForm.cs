using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainForm : Form
    {
        // Shared data structures for the application
        private BinarySearchTree<IssueReport> bst;
        private AVLTree<IssueReport> avlTree;
        private RedBlackTree<IssueReport> redBlackTree;

        public MainForm()
        {
            InitializeComponent();
            InitializeSharedDataStructures();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Optional: Add logic for initialization when the form loads
        }

        private void InitializeSharedDataStructures()
        {
            bst = new BinarySearchTree<IssueReport>();
            avlTree = new AVLTree<IssueReport>();
            redBlackTree = new RedBlackTree<IssueReport>();

            AddSampleData();
        }

       private void AddSampleData()
{
    var sampleIssues = new[]
    {
        new IssueReport
        {
            Id = 1,
            Description = "Water leak on main street",
            Status = "Pending",
            Category = "Water Issue",
            Location = "Johannesburg South",
            Priority = 3,
            DateSubmitted = DateTime.Now.AddDays(-10)
        },
        new IssueReport
        {
            Id = 2,
            Description = "Streetlight not working",
            Status = "In Progress",
            Category = "Electricity",
            Location = "Pretoria",
            Priority = 2,
            DateSubmitted = DateTime.Now.AddDays(-9)
        },
        new IssueReport
        {
            Id = 3,
            Description = "Pothole on Elm Street",
            Status = "Resolved",
            Category = "Pothole",
            Location = "Johannesburg North",
            Priority = 1,
            DateSubmitted = DateTime.Now.AddDays(-8)
        },
        new IssueReport
        {
            Id = 4,
            Description = "Broken water pipe near park",
            Status = "Pending",
            Category = "Water Issue",
            Location = "Centurion",
            Priority = 4,
            DateSubmitted = DateTime.Now.AddDays(-7)
        },
        new IssueReport
        {
            Id = 5,
            Description = "Traffic signal malfunction",
            Status = "In Progress",
            Category = "Electricity",
            Location = "Sandton",
            Priority = 2,
            DateSubmitted = DateTime.Now.AddDays(-6)
        },
        new IssueReport
        {
            Id = 6,
            Description = "Tree branch blocking street",
            Status = "Resolved",
            Category = "Other",
            Location = "Midrand",
            Priority = 1,
            DateSubmitted = DateTime.Now.AddDays(-5)
        },
        new IssueReport
        {
            Id = 7,
            Description = "Illegal dumping reported",
            Status = "Pending",
            Category = "Other",
            Location = "Soweto",
            Priority = 3,
            DateSubmitted = DateTime.Now.AddDays(-4)
        },
        new IssueReport
        {
            Id = 8,
            Description = "Collapsed sidewalk",
            Status = "In Progress",
            Category = "Pothole",
            Location = "Johannesburg East",
            Priority = 4,
            DateSubmitted = DateTime.Now.AddDays(-3)
        },
        new IssueReport
        {
            Id = 9,
            Description = "Power outage in residential area",
            Status = "Resolved",
            Category = "Electricity",
            Location = "Roodepoort",
            Priority = 2,
            DateSubmitted = DateTime.Now.AddDays(-2)
        },
        new IssueReport
        {
            Id = 10,
            Description = "Overflowing stormwater drain",
            Status = "Pending",
            Category = "Water Issue",
            Location = "Randburg",
            Priority = 5,
            DateSubmitted = DateTime.Now.AddDays(-1)
        }
    };

    // Add dependencies
    sampleIssues[0].Dependencies.Add(sampleIssues[3]); // Issue 1 depends on Issue 4
    sampleIssues[0].Dependencies.Add(sampleIssues[2]); // Issue 1 depends on Issue 3
    sampleIssues[4].Dependencies.Add(sampleIssues[1]); // Issue 5 depends on Issue 2
    sampleIssues[7].Dependencies.Add(sampleIssues[6]); // Issue 8 depends on Issue 7
    sampleIssues[9].Dependencies.Add(sampleIssues[5]); // Issue 10 depends on Issue 6

    // Populate trees
    foreach (var issue in sampleIssues)
    {
        bst.Insert(issue);
        avlTree.Insert(issue);
        redBlackTree.Insert(issue);
    }
}


        private int GenerateNextId()
        {
            return bst.Count() + 1; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportIssuesForm(bst, avlTree, redBlackTree, GenerateNextId);
            reportForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var localEventsForm = new LocalEventsForm();
            localEventsForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var serviceRequestsBST = new BinarySearchTree<ServiceRequest>();
            var serviceRequestsAVL = new AVLTree<ServiceRequest>();
            var serviceRequestsRBT = new RedBlackTree<ServiceRequest>();

            var issueToServiceRequestMap = new Dictionary<IssueReport, ServiceRequest>();

            foreach (var issue in bst.InOrderTraversal())
            {
                var serviceRequest = new ServiceRequest(
                    id: issue.Id.ToString(),
                    description: issue.Description,
                    status: issue.Status,
                    priority: issue.Priority,
                    category: issue.Category,
                    location: issue.Location,
                    dateSubmitted: issue.DateSubmitted
                );

                // Add to mapping dictionary
                issueToServiceRequestMap[issue] = serviceRequest;

                serviceRequestsBST.Insert(serviceRequest);
                serviceRequestsAVL.Insert(serviceRequest);
                serviceRequestsRBT.Insert(serviceRequest);
            }

            // Add dependencies to ServiceRequests
            foreach (var issue in bst.InOrderTraversal())
            {
                if (issue.Dependencies != null && issue.Dependencies.Count > 0)
                {
                    var serviceRequest = issueToServiceRequestMap[issue];

                    foreach (var dependency in issue.Dependencies)
                    {
                        if (issueToServiceRequestMap.TryGetValue(dependency, out var dependentServiceRequest))
                        {
                            serviceRequest.Dependencies.Add(dependentServiceRequest);
                        }
                    }
                }
            }

            var serviceRequestStatusForm = new ServiceRequestStatusForm(
                serviceRequestsBST,
                serviceRequestsAVL,
                serviceRequestsRBT
            );
            serviceRequestStatusForm.ShowDialog();
        }
    }
}
