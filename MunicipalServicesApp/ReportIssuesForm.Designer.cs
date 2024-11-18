using System;
using System.Drawing;
using System.Windows.Forms;


// ST10067040



namespace MunicipalServicesApp
{
    partial class ReportIssuesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Button btnUploadAttachment;
        private System.Windows.Forms.ListBox lstAttachments;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel buttonPanel;


    

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
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.btnUploadAttachment = new System.Windows.Forms.Button();
            this.lstAttachments = new System.Windows.Forms.ListBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel(); 
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(32, 34, 37);
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.Controls.Add(this.lblLocation, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtLocation, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblCategory, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.cboCategory, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblDescription, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.txtDescription, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.btnUploadAttachment, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.lstAttachments, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonPanel, 1, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1044, 532);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = System.Drawing.Color.LightGray;
            this.lblLocation.Location = new System.Drawing.Point(13, 10);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(78, 23);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLocation.Margin = new System.Windows.Forms.Padding(5);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(700, 22);
            this.txtLocation.TabIndex = 1;
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(26, 28, 30);
            this.txtLocation.ForeColor = System.Drawing.Color.White;
            this.txtLocation.Padding = new System.Windows.Forms.Padding(5);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.LightGray;
            this.lblCategory.Location = new System.Drawing.Point(13, 50);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(84, 23);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";
            // 
            // cboCategory
            // 
          
            this.cboCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCategory.Margin = new System.Windows.Forms.Padding(5);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(700, 24);
            this.cboCategory.BackColor = System.Drawing.Color.FromArgb(26, 28, 30);
            this.cboCategory.ForeColor = System.Drawing.Color.White;
            this.cboCategory.TabIndex = 2;
            
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.LightGray;
            this.lblDescription.Location = new System.Drawing.Point(13, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(102, 23);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDescription.Margin = new System.Windows.Forms.Padding(5);
            this.txtDescription.Size = new System.Drawing.Size(700, 110);
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(26, 28, 30);
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.TabIndex = 4;
            // 
            // btnUploadAttachment
            // 
            this.btnUploadAttachment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUploadAttachment.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnUploadAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadAttachment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadAttachment.ForeColor = System.Drawing.Color.White;
            this.btnUploadAttachment.Location = new System.Drawing.Point(13, 220);
            this.btnUploadAttachment.Name = "btnUploadAttachment";
            this.btnUploadAttachment.Size = new System.Drawing.Size(200, 40);
            this.btnUploadAttachment.TabIndex = 5;
            this.btnUploadAttachment.Text = "Upload Attachment";
            this.btnUploadAttachment.UseVisualStyleBackColor = false;
            this.btnUploadAttachment.Click += new System.EventHandler(this.btnUploadAttachment_Click_1);
            // 
            // lstAttachments
            // 
            this.lstAttachments.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstAttachments.Size = new System.Drawing.Size(700, 50);
            this.lstAttachments.BackColor = System.Drawing.Color.FromArgb(26, 28, 30);
            this.lstAttachments.ForeColor = System.Drawing.Color.White;
            this.lstAttachments.TabIndex = 6;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonPanel.Controls.Add(this.btnBack);
            this.buttonPanel.Controls.Add(this.btnSubmit);
            this.buttonPanel.Location = new System.Drawing.Point((this.ClientSize.Width - this.buttonPanel.Width) / 2, this.ClientSize.Height - this.buttonPanel.Height - 20); // Dynamically center horizontally and set vertical position
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(300, 50);
            this.buttonPanel.TabIndex = 7;

            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(150, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(150, 40);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click_1);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 40);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // ReportIssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 532);
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "ReportIssuesForm";
            this.Text = "Report Issues";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }
        private void ControlPaintBorder(object sender, PaintEventArgs e)
        {
            Control control = (Control)sender;
            Graphics graphics = e.Graphics;

            Rectangle rect = new Rectangle(0, 0, control.Width - 1, control.Height - 1);
            Color borderColor = Color.LightGray;

            ControlPaint.DrawBorder(graphics, rect, borderColor, ButtonBorderStyle.Solid);
        }
    }
}
