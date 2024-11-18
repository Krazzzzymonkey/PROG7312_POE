using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    partial class ServiceRequestStatusForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewRequests;
        private TextBox textBoxSearchById;
        private ComboBox comboBoxStatus;
        private ComboBox comboBoxLocation;
        private ComboBox comboBoxPriority;
        private ComboBox comboBoxSortByPriority;
        private DateTimePicker dateTimePickerStartDate;
        private DateTimePicker dateTimePickerEndDate;
        private Button buttonClearFilters;
        private Button buttonShowDependencies;
        private Button buttonVisualizeDependencies;
        private Button buttonVisualizeAllDependencies;
        private Label labelSearchById;
        private Label labelStatusFilter;
        private Label labelLocationFilter;
        private Label labelPriorityFilter;
        private Label labelSortByPriority;
        private Label labelDateRange;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Text = "Service Request Status";
            this.BackColor = Color.FromArgb(32, 34, 37);

            // ListView for requests
            this.listViewRequests = new ListView
            {
                Location = new Point(15, 170),
                Size = new Size(770, 340),
                FullRowSelect = true,
                GridLines = true,
                View = View.Details,
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.listViewRequests.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader { Text = "ID", Width = 50 },
                new ColumnHeader { Text = "Category", Width = 100 },
                new ColumnHeader { Text = "Description", Width = 200 },
                new ColumnHeader { Text = "Status", Width = 100 },
                new ColumnHeader { Text = "Location", Width = 150 },
                new ColumnHeader { Text = "Date Submitted", Width = 120 },
                new ColumnHeader { Text = "Priority", Width = 45 }
            });

            // TextBox for search by ID
            this.textBoxSearchById = new TextBox
            {
                Location = new Point(15, 30),
                Size = new Size(150, 20),
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.textBoxSearchById.TextChanged += new EventHandler(this.textBoxSearchById_TextChanged);

            // ComboBox for Status
            this.comboBoxStatus = new ComboBox
            {
                Location = new Point(235, 30),
                Size = new Size(150, 21),
                //DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.comboBoxStatus.SelectedIndexChanged += new EventHandler(this.comboBoxStatus_SelectedIndexChanged);

            // ComboBox for Location
            this.comboBoxLocation = new ComboBox
            {
                Location = new Point(455, 30),
                Size = new Size(150, 21),
                //DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.comboBoxLocation.SelectedIndexChanged += new EventHandler(this.comboBoxLocation_SelectedIndexChanged);

            // ComboBox for Priority
            this.comboBoxPriority = new ComboBox
            {
                Location = new Point(15, 70),
                Size = new Size(150, 21),
                //DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.comboBoxPriority.SelectedIndexChanged += new EventHandler(this.comboBoxPriority_SelectedIndexChanged);

            // ComboBox for Sort by Priority
            this.comboBoxSortByPriority = new ComboBox
            {
                Location = new Point(235, 70),
                Size = new Size(150, 21),
                //DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.comboBoxSortByPriority.Items.AddRange(new object[] { "N/A", "Ascending", "Descending" });
            this.comboBoxSortByPriority.SelectedIndex = 0;
            this.comboBoxSortByPriority.SelectedIndexChanged += new EventHandler(this.comboBoxSortByPriority_SelectedIndexChanged);

            // Date range pickers
            this.dateTimePickerStartDate = new DateTimePicker
            {
                Location = new Point(455, 70),
                Size = new Size(150, 20),
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.dateTimePickerStartDate.ValueChanged += new EventHandler(this.dateTimePickerStartDate_ValueChanged);

            this.dateTimePickerEndDate = new DateTimePicker
            {
                Location = new Point(615, 70),
                Size = new Size(150, 20),
                BackColor = Color.FromArgb(26, 28, 30),
                ForeColor = Color.White
            };
            this.dateTimePickerEndDate.ValueChanged += new EventHandler(this.dateTimePickerEndDate_ValueChanged);

            // Buttons
            this.buttonClearFilters = new Button
            {
                Location = new Point(615, 30),
                Size = new Size(150, 20),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                Text = "Clear Filters"
            };
            this.buttonClearFilters.Click += new EventHandler(this.buttonClearFilters_Click);

            this.buttonShowDependencies = new Button
            {
                Location = new Point(185, 130),
                Size = new Size(210, 30),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                Text = "Show Selected Issue's Dependencies"
            };
            this.buttonShowDependencies.Click += new EventHandler(this.buttonShowDependencies_Click);

            this.buttonVisualizeDependencies = new Button
            {
                Location = new Point(405, 130),
                Size = new Size(210, 30),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                Text = "Visualize Selected Issue's Dependencies"
            };
            this.buttonVisualizeDependencies.Click += new EventHandler(this.buttonVisualizeDependencies_Click);

            this.buttonVisualizeAllDependencies = new Button
            {
                Location = new Point(295, 520),
                Size = new Size(210, 30),
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                Text = "Visualize All Dependencies"
            };
            this.buttonVisualizeAllDependencies.Click += new EventHandler(this.buttonVisualizeAllDependencies_Click);

            // Labels
            this.labelSearchById = new Label
            {
                Location = new Point(15, 12),
                Size = new Size(200, 15),
                ForeColor = Color.LightGray,
                Text = "Search by ID:"
            };

            this.labelStatusFilter = new Label
            {
                Location = new Point(235, 12),
                Size = new Size(150, 15),
                ForeColor = Color.LightGray,
                Text = "Filter by Status:"
            };

            this.labelLocationFilter = new Label
            {
                Location = new Point(455, 12),
                Size = new Size(150, 15),
                ForeColor = Color.LightGray,
                Text = "Filter by Location:"
            };

            this.labelPriorityFilter = new Label
            {
                Location = new Point(15, 52),
                Size = new Size(150, 15),
                ForeColor = Color.LightGray,
                Text = "Filter by Priority:"
            };

            this.labelSortByPriority = new Label
            {
                Location = new Point(235, 52),
                Size = new Size(150, 15),
                ForeColor = Color.LightGray,
                Text = "Sort by Priority:"
            };

            this.labelDateRange = new Label
            {
                Location = new Point(455, 52),
                Size = new Size(150, 15),
                ForeColor = Color.LightGray,
                Text = "Filter by Date Range:"
            };

            // Add controls to the form
            this.Controls.Add(this.listViewRequests);
            this.Controls.Add(this.textBoxSearchById);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxLocation);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.comboBoxSortByPriority);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.buttonClearFilters);
            this.Controls.Add(this.buttonShowDependencies);
            this.Controls.Add(this.buttonVisualizeDependencies);
            this.Controls.Add(this.buttonVisualizeAllDependencies);
            this.Controls.Add(this.labelSearchById);
            this.Controls.Add(this.labelStatusFilter);
            this.Controls.Add(this.labelLocationFilter);
            this.Controls.Add(this.labelPriorityFilter);
            this.Controls.Add(this.labelSortByPriority);
            this.Controls.Add(this.labelDateRange);
        }
        #endregion
    }
}
