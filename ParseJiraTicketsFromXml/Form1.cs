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
    }
}
