using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JiraXmlParser;
namespace ParseJiraTicketsFromXml
{
    public partial class Form1 : Form
    {
        JiraTicketsEntities _EF = new JiraTicketsEntities();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }      

        private void LoadData()
        {
            dgReports.DataSource = null;
            dgReports.AutoGenerateColumns = false;
            var reportData = (from tickets in _EF.JiraTickets
                              where tickets.IsDeleted == false
                              select tickets)
                             .OrderBy(r => r.assignee)
                             .ThenBy(r => r.key);

            dgReports.DataSource = reportData.ToList();
            lblTotalRecords.Text = "Total tickets: " + (from vr in reportData select vr.key).Distinct().Count().ToString();
            InsertColorsToData();
        }
        private void btnLoadXmlFile_Click(object sender, EventArgs e)
        {
            #region Load xml file
            XmlParser xmlParser = new XmlParser();
            openXmlFileDialoge.ShowDialog();
            var filePath = openXmlFileDialoge.FileName;
            List<TickectModal> tickets = xmlParser.ReadFromFile(filePath);
            DateTime currentFileDate = new DateTime();
            currentFileDate = xmlParser.xmlDownloadDate;
            #endregion

            #region remove old records for same date
            var oldRecords = _EF.JiraTickets.Where(r => r.RecordCreationDate == currentFileDate);
            _EF.JiraTickets.RemoveRange(oldRecords);
            _EF.SaveChanges();
            #endregion

            foreach (TickectModal ticket in tickets)
            {
                JiraTicket _efTicket = new JiraTicket();
                _efTicket.key = ticket.key;
                _efTicket.summary = ticket.summary;
                _efTicket.link = ticket.link;
                _efTicket.type = ticket.type;
                _efTicket.status = ticket.status;
                _efTicket.assignee = ticket.assignee;
                if (!string.IsNullOrEmpty(ticket.createdDate))
                    _efTicket.createdDate = Convert.ToDateTime(ticket.createdDate);
                if (!string.IsNullOrEmpty(ticket.updatedDate))
                    _efTicket.updatedDate = Convert.ToDateTime(ticket.updatedDate);
                _efTicket.aggregatetimeoriginalestimate = ticket.aggregatetimeoriginalestimate;
                _efTicket.aggregatetimeremainingestimate = ticket.aggregatetimeremainingestimate;
                _efTicket.aggregatetimespent = ticket.aggregatetimespent;
                _efTicket.RecordCreationDate = currentFileDate;
                _efTicket.IsDeleted = false;
                _EF.JiraTickets.Add(_efTicket);
            }
            
            _EF.SaveChanges();
            this.CleanUpOldTickets(currentFileDate, tickets);
            MessageBox.Show(this,"Hogaya Kaam","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadData();
        }

        private void CleanUpOldTickets(DateTime currentFileDate, List<TickectModal> newTickets)
        {
            //mark as deleted all those tickets which does not exists in current list
            List<JiraTicket> CurrentTicketsInDb = _EF.JiraTickets.Where(r => r.RecordCreationDate < currentFileDate && r.IsDeleted == false).ToList();
            foreach (JiraTicket oldTicket in CurrentTicketsInDb)
            {
                var exists = (from result in newTickets where result.key == oldTicket.key && result.assignee == oldTicket.assignee select result).FirstOrDefault();
                if(exists == null)
                {
                    oldTicket.IsDeleted = true;
                    _EF.SaveChanges();
                }
            }
        }

        string assigneeName = string.Empty;
        Color newColor = Color.LightGreen;
        string ticketNumber = string.Empty;
        Color ticketColor = Color.LightBlue;
        private void InsertColorsToData()
        {
            if (dgReports.Rows.Count == 0)
                return;
            assigneeName = dgReports.Rows[0].Cells["assignee"].Value.ToString();
            ticketNumber = dgReports.Rows[0].Cells["key"].Value.ToString();

            foreach (DataGridViewRow row in dgReports.Rows)
            {
                if (row.Cells["assignee"].Value.ToString() == assigneeName)
                {
                    row.Cells["assignee"].Style.BackColor = newColor;
                }
                else
                {
                    assigneeName = row.Cells["assignee"].Value.ToString();
                    if (newColor == Color.LightGreen)
                        newColor = Color.LightCoral;
                    else
                        newColor = Color.LightGreen;
                    row.Cells["assignee"].Style.BackColor = newColor;
                }

                if (row.Cells["key"].Value.ToString() == ticketNumber)
                {
                    row.Cells["key"].Style.BackColor = ticketColor;
                    row.Cells["RecordCreationDate"].Style.BackColor = ticketColor;
                }
                else
                {
                    ticketNumber = row.Cells["key"].Value.ToString();
                    if (ticketColor == Color.LightBlue)
                        ticketColor = Color.LightPink;
                    else
                        ticketColor = Color.LightBlue;
                    row.Cells["key"].Style.BackColor = ticketColor;
                    row.Cells["RecordCreationDate"].Style.BackColor = ticketColor;
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            // Copy all to clipboard 
            /*dgReports.SelectAll(); 
            DataObject dataObj = dgReports.GetClipboardContent(); 
            if (dataObj != null) Clipboard.SetDataObject(dataObj); 
            // Paste in Excel 
            Microsoft.Office.Interop.Excel.Application xlexcel; 
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook; 
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet; 
            object misValue = System.Reflection.Missing.Value; 
            xlexcel = new Microsoft.Office.Interop.Excel.Application(); 
            //xlexcel.Visible = true; 
            xlWorkBook = xlexcel.Workbooks.Add(misValue); 
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); 
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1]; 
            CR.Select(); 
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, false);
            xlWorkBook.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            xlexcel.Quit();
            */


            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            //app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "All resources";
            // storing header part in Excel  
            for (int i = 1; i < dgReports.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgReports.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dgReports.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgReports.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgReports.Rows[i].Cells[j].Value.ToString();
                }
            }
           
            // save the application  
            workbook.SaveAs(saveFileDialog1.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
            MessageBox.Show("Data Exported");
        }
    }
}
