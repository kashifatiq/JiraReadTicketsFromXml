namespace ParseJiraTicketsFromXml
{
    partial class Form1
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
            this.openXmlFileDialoge = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadXmlFile = new System.Windows.Forms.Button();
            this.dgReports = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalRecords = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.assignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordCreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aggregatetimeoriginalestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aggregatetimespent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aggregatetimeremainingestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.link = new System.Windows.Forms.DataGridViewLinkColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgReports)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openXmlFileDialoge
            // 
            this.openXmlFileDialoge.FileName = "openFileDialog1";
            // 
            // btnLoadXmlFile
            // 
            this.btnLoadXmlFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadXmlFile.Location = new System.Drawing.Point(0, 23);
            this.btnLoadXmlFile.Name = "btnLoadXmlFile";
            this.btnLoadXmlFile.Size = new System.Drawing.Size(1217, 35);
            this.btnLoadXmlFile.TabIndex = 0;
            this.btnLoadXmlFile.Text = "Load Xml File";
            this.btnLoadXmlFile.UseVisualStyleBackColor = true;
            this.btnLoadXmlFile.Click += new System.EventHandler(this.btnLoadXmlFile_Click);
            // 
            // dgReports
            // 
            this.dgReports.AllowUserToAddRows = false;
            this.dgReports.AllowUserToDeleteRows = false;
            this.dgReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.assignee,
            this.key,
            this.RecordCreationDate,
            this.status,
            this.aggregatetimeoriginalestimate,
            this.aggregatetimespent,
            this.aggregatetimeremainingestimate,
            this.summary,
            this.link,
            this.type});
            this.dgReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReports.Location = new System.Drawing.Point(0, 0);
            this.dgReports.Name = "dgReports";
            this.dgReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReports.ShowEditingIcon = false;
            this.dgReports.Size = new System.Drawing.Size(1217, 552);
            this.dgReports.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalRecords});
            this.statusStrip1.Location = new System.Drawing.Point(0, 616);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1217, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(0, 17);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExportToExcel.Location = new System.Drawing.Point(0, 0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(1217, 23);
            this.btnExportToExcel.TabIndex = 3;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.FileName = "Jira Tickets List";
            this.saveFileDialog1.InitialDirectory = "D:\\";
            this.saveFileDialog1.Title = "Save Excel File";
            // 
            // assignee
            // 
            this.assignee.DataPropertyName = "assignee";
            this.assignee.HeaderText = "assignee";
            this.assignee.Name = "assignee";
            this.assignee.Width = 74;
            // 
            // key
            // 
            this.key.DataPropertyName = "key";
            this.key.HeaderText = "key";
            this.key.Name = "key";
            this.key.Width = 49;
            // 
            // RecordCreationDate
            // 
            this.RecordCreationDate.DataPropertyName = "RecordCreationDate";
            this.RecordCreationDate.HeaderText = "Report Date";
            this.RecordCreationDate.Name = "RecordCreationDate";
            this.RecordCreationDate.Width = 90;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.Width = 60;
            // 
            // aggregatetimeoriginalestimate
            // 
            this.aggregatetimeoriginalestimate.DataPropertyName = "aggregatetimeoriginalestimate";
            this.aggregatetimeoriginalestimate.HeaderText = "LOE";
            this.aggregatetimeoriginalestimate.Name = "aggregatetimeoriginalestimate";
            this.aggregatetimeoriginalestimate.Width = 53;
            // 
            // aggregatetimespent
            // 
            this.aggregatetimespent.DataPropertyName = "aggregatetimespent";
            this.aggregatetimespent.HeaderText = "Work Log";
            this.aggregatetimespent.Name = "aggregatetimespent";
            this.aggregatetimespent.Width = 79;
            // 
            // aggregatetimeremainingestimate
            // 
            this.aggregatetimeremainingestimate.DataPropertyName = "aggregatetimeremainingestimate";
            this.aggregatetimeremainingestimate.HeaderText = "Time Remaining";
            this.aggregatetimeremainingestimate.Name = "aggregatetimeremainingestimate";
            this.aggregatetimeremainingestimate.Width = 99;
            // 
            // summary
            // 
            this.summary.DataPropertyName = "summary";
            this.summary.HeaderText = "summary";
            this.summary.Name = "summary";
            this.summary.Width = 73;
            // 
            // link
            // 
            this.link.DataPropertyName = "link";
            this.link.HeaderText = "link";
            this.link.Name = "link";
            this.link.Width = 29;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.Width = 52;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadXmlFile);
            this.panel1.Controls.Add(this.btnExportToExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1217, 64);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgReports);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1217, 552);
            this.panel2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 638);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Read Jira Tickets from XML";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgReports)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openXmlFileDialoge;
        private System.Windows.Forms.Button btnLoadXmlFile;
        private System.Windows.Forms.DataGridView dgReports;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalRecords;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordCreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn aggregatetimeoriginalestimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn aggregatetimespent;
        private System.Windows.Forms.DataGridViewTextBoxColumn aggregatetimeremainingestimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn summary;
        private System.Windows.Forms.DataGridViewLinkColumn link;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

