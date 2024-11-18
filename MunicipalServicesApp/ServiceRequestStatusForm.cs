using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ServiceRequestStatusForm : Form
    {
        private BinarySearchTree<ServiceRequest> bst;
        private AVLTree<ServiceRequest> avlTree;
        private RedBlackTree<ServiceRequest> redBlackTree;
        private Graph<ServiceRequest> dependencyGraph;
        private List<ServiceRequest> allRequests;

        public ServiceRequestStatusForm(
            BinarySearchTree<ServiceRequest> bst,
            AVLTree<ServiceRequest> avlTree,
            RedBlackTree<ServiceRequest> redBlackTree)
        {
            InitializeComponent();

            this.bst = bst;
            this.avlTree = avlTree;
            this.redBlackTree = redBlackTree;

            // Initialize dataset
            allRequests = bst.InOrderTraversal();
            dependencyGraph = new Graph<ServiceRequest>();

            // Populate graph and other UI elements
            PopulateGraph(allRequests);
            PopulateListView(allRequests);
            PopulateFilters();


            // Reset Filters and Repopulate
            textBoxSearchById.Clear();
            comboBoxStatus.SelectedIndex = 0;
            comboBoxLocation.SelectedIndex = 0;
            comboBoxPriority.SelectedIndex = 0;
            dateTimePickerStartDate.Value = DateTime.Now.AddDays(-30);
            dateTimePickerEndDate.Value = DateTime.Now;

            // Repopulate with full dataset
            PopulateListView(allRequests);
            ApplyFilters();
        }

        private void PopulateGraph(IEnumerable<ServiceRequest> requests)
        {
            // Add nodes to the graph
            foreach (var request in requests)
            {
                dependencyGraph.AddNode(request);
            }

            // Add edges based on explicit dependencies
            foreach (var request in requests)
            {
                foreach (var dependency in request.Dependencies)
                {
                    dependencyGraph.AddEdge(request, dependency);
                }
            }
        }



        private void PopulateListView(IEnumerable<ServiceRequest> requests)
        {
            listViewRequests.Items.Clear();

            foreach (var request in requests)
            {
                var item = new ListViewItem(request.Id.ToString());
                item.SubItems.Add(request.Category);
                item.SubItems.Add(request.Description);
                item.SubItems.Add(request.Status);
                item.SubItems.Add(request.Location);
                item.SubItems.Add(request.DateSubmitted.ToShortDateString());
                item.SubItems.Add(request.Priority.ToString());
                listViewRequests.Items.Add(item);
            }
        }

        private void PopulateFilters()
        {
            comboBoxStatus.Items.Clear();
            comboBoxLocation.Items.Clear();
            comboBoxPriority.Items.Clear();

            comboBoxStatus.Items.Add("All");
            comboBoxStatus.Items.AddRange(allRequests.Select(r => r.Status).Distinct().ToArray());

            comboBoxLocation.Items.Add("All");
            comboBoxLocation.Items.AddRange(allRequests.Select(r => r.Location).Distinct().ToArray());

            comboBoxPriority.Items.Add("All");
            comboBoxPriority.Items.AddRange(
                allRequests
                .Select(r => r.Priority)
                .Distinct()
                .OrderBy(priority => priority)
                .Select(priority => priority.ToString())
                .ToArray()
            );


            comboBoxStatus.SelectedIndex = 0;
            comboBoxLocation.SelectedIndex = 0;
            comboBoxPriority.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            var displayedRequests = allRequests; // Start with all data

            string idFilter = textBoxSearchById.Text.ToLower();
            string statusFilter = comboBoxStatus.SelectedItem?.ToString();
            string locationFilter = comboBoxLocation.SelectedItem?.ToString();
            string priorityFilter = comboBoxPriority.SelectedItem?.ToString();
            DateTime startDate = dateTimePickerStartDate.Value.Date;
            DateTime endDate = dateTimePickerEndDate.Value.Date;

            if (!string.IsNullOrEmpty(idFilter))
            {
                displayedRequests = displayedRequests
                    .Where(r => r.Id.ToString().Contains(idFilter))
                    .ToList();
            }

            if (statusFilter != "All")
            {
                displayedRequests = displayedRequests
                    .Where(r => r.Status == statusFilter)
                    .ToList();
            }

            if (locationFilter != "All")
            {
                displayedRequests = displayedRequests
                    .Where(r => r.Location == locationFilter)
                    .ToList();
            }

            if (priorityFilter != "All" && int.TryParse(priorityFilter, out int priorityValue))
            {
                displayedRequests = displayedRequests
                    .Where(r => r.Priority == priorityValue)
                    .ToList();
            }

            displayedRequests = displayedRequests
                .Where(r => r.DateSubmitted.Date >= startDate && r.DateSubmitted.Date <= endDate)
                .ToList();

            
            if (comboBoxSortByPriority.SelectedItem?.ToString() == "Ascending")
            {
                displayedRequests = displayedRequests
                    .OrderBy(r => r.Priority)
                    .ToList();
            }
            else if (comboBoxSortByPriority.SelectedItem?.ToString() == "Descending")
            {
                displayedRequests = displayedRequests
                    .OrderByDescending(r => r.Priority)
                    .ToList();
            }else
            {
                // Fallback: Sort by ID numerically
                displayedRequests = displayedRequests
                    .OrderBy(r => int.TryParse(r.Id.ToString(), out int numericId) ? numericId : int.MaxValue)
                    .ToList();

            }

            PopulateListView(displayedRequests);
        }

        private void ShowGraphVisualization(ServiceRequest selectedRequest)
        {
            if (selectedRequest == null)
            {
                MessageBox.Show("No service request selected.", "Error");
                return;
            }

            // Create a new temporary graph for the selected request and its dependencies
            var filteredGraph = new Graph<ServiceRequest>();

            // Add the selected node
            filteredGraph.AddNode(selectedRequest);

            // Add dependencies
            foreach (var dependency in dependencyGraph.GetDependencies(selectedRequest))
            {
                filteredGraph.AddNode(dependency);
                filteredGraph.AddEdge(selectedRequest, dependency);
            }

            var graphVisualizer = new GraphVisualizer<ServiceRequest>(filteredGraph);
            string dotGraph = graphVisualizer.ExportToDot(r => $"Request {r.Id}: {r.Description}");

            try
            {
                var graphImage = GraphRenderer.RenderGraph(dotGraph);

                // Show the graph in a new form
                var graphForm = new Form
                {
                    Text = $"Dependency Graph for Request {selectedRequest.Id}",
                    Size = new Size(800, 600)
                };

                var pictureBox = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    Image = graphImage,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                graphForm.Controls.Add(pictureBox);
                graphForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                MessageBox.Show($"Error rendering graph: {ex.Message}", "Error");
            }
        }
        private void ShowDependencies(ServiceRequest request)
        {
            var dependencies = dependencyGraph.GetDependencies(request);

            if (dependencies.Count == 0)
            {
                MessageBox.Show("No dependencies for this request.", "Dependencies");
                return;
            }

            string message = "Dependencies:\n";
            foreach (var dependency in dependencies)
            {
                message += $"- ID: {dependency.Id}, Description: {dependency.Description}, Status: {dependency.Status}\n";
            }

            MessageBox.Show(message, "Dependencies");
        }
        
        private void buttonShowDependencies_Click(object sender, EventArgs e)
        {
            if (listViewRequests.SelectedItems.Count > 0)
            {
                int selectedId = int.Parse(listViewRequests.SelectedItems[0].Text);
                var request = allRequests.FirstOrDefault(r => int.Parse(r.Id) == selectedId);

                if (request != null)
                {
                    ShowDependencies(request);
                }
                else
                {
                    MessageBox.Show("Request not found.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a request.", "Error");
            }
        }


        private void buttonVisualizeDependencies_Click(object sender, EventArgs e)
        {
            if (listViewRequests.SelectedItems.Count > 0)
            {
                int selectedId = int.Parse(listViewRequests.SelectedItems[0].Text);
                var selectedRequest = allRequests.FirstOrDefault(r => int.Parse(r.Id) == selectedId);

                if (selectedRequest != null)
                {
                    ShowGraphVisualization(selectedRequest);
                }
                else
                {
                    MessageBox.Show("Request not found.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a request.", "Error");
            }
        }

        private void buttonVisualizeAllDependencies_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate the DOT graph for all dependencies
                var graphVisualizer = new GraphVisualizer<ServiceRequest>(dependencyGraph);
                string dotGraph = graphVisualizer.ExportToDot(node => $"Request {node.Id}: {node.Description}");

                // Render the graph into an image
                var graphImage = GraphRenderer.RenderGraph(dotGraph);

                // Get the size of the graph image
                var imageSize = graphImage.Size;

                // Display the graph in a new form
                var graphForm = new Form
                {
                    Text = "All Dependencies",
                    Size = new Size(imageSize.Width + 16, imageSize.Height + 39) // Adjust for form borders and title bar
                };

                var pictureBox = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    Image = graphImage,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                graphForm.Controls.Add(pictureBox);
                graphForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error visualizing dependencies: {ex.Message}", "Error");
            }
        }




        private void comboBoxSortByPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void textBoxSearchById_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            // Reset Filters and Repopulate
            textBoxSearchById.Clear();
            comboBoxStatus.SelectedIndex = 0;
            comboBoxLocation.SelectedIndex = 0;
            comboBoxPriority.SelectedIndex = 0;
            comboBoxSortByPriority.SelectedIndex = 0;
            dateTimePickerStartDate.Value = DateTime.Now.AddDays(-30);
            dateTimePickerEndDate.Value = DateTime.Now;
           
            // Repopulate with full dataset
            PopulateListView(allRequests);
        }
    }
}
