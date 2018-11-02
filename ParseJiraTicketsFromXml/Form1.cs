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
        }
        private void btnLoadXmlFile_Click(object sender, EventArgs e)
        {
            XmlParser xmlParser = new XmlParser();
            openXmlFileDialoge.ShowDialog();
            var filePath = openXmlFileDialoge.FileName;
            List<TickectModal> tickets = xmlParser.ReadFromFile(filePath);
            DateTime currentFileDate = new DateTime();
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
                _efTicket.RecordCreationDate = Convert.ToDateTime(ticket.xmlDownloadDate);
                _efTicket.IsDeleted = false;
                currentFileDate = Convert.ToDateTime(ticket.xmlDownloadDate);
                _EF.JiraTickets.Add(_efTicket);
            }
            var oldRecords = _EF.JiraTickets.Where(r => r.RecordCreationDate == currentFileDate);
            _EF.JiraTickets.RemoveRange(oldRecords);
            _EF.SaveChanges();
            //this.CleanUpOldTickets(currentFileDate, tickets);
            MessageBox.Show(this,"Hogaya Kaam","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadData();
        }

        private void CleanUpOldTickets(DateTime currentFileDate, List<TickectModal> newTickets)
        {
            //mark as deleted all those tickets which does not exists in current list
            List<JiraTicket> CurrentTicketsInDb = _EF.JiraTickets.Where(r => r.RecordCreationDate != currentFileDate && r.IsDeleted == false).ToList();
            foreach (JiraTicket oldTicket in CurrentTicketsInDb)
            {
                if(!newTickets.Exists(r => r.key == oldTicket.key))
                {
                    oldTicket.IsDeleted = true;
                    _EF.SaveChanges();
                }
            }
        }

        string assigneeName = string.Empty;
        string ticketNumber = string.Empty;
        string vrsummary = string.Empty;
        string vrlink = string.Empty;
        string vrtype = string.Empty;
        private void dgReports_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //foreach (DataGridViewRow row in dgReports.Rows)
            //{
            //    if (row.Cells["assignee"].Value.ToString() == assigneeName)
            //    {
            //        JiraTicket dd = (JiraTicket)row.DataBoundItem;
            //        dd.assignee = "";
            //    }
            //    else
            //        assigneeName = row.Cells["assignee"].Value.ToString();

            //    if (row.Cells["key"].Value.ToString() == ticketNumber)
            //    {
            //        JiraTicket dd = (JiraTicket)row.DataBoundItem;
            //        dd.key = "";
            //    }
            //    else
            //        ticketNumber = row.Cells["key"].Value.ToString();

            //    if (row.Cells["summary"].Value.ToString() == vrsummary)
            //    {
            //        JiraTicket dd = (JiraTicket)row.DataBoundItem;
            //        dd.summary = "";
            //    }
            //    else
            //        vrsummary = row.Cells["summary"].Value.ToString();

            //    if (row.Cells["link"].Value.ToString() == vrlink)
            //    {
            //        JiraTicket dd = (JiraTicket)row.DataBoundItem;
            //        dd.link = "";
            //    }
            //    else
            //        vrlink = row.Cells["link"].Value.ToString();

            //    if (row.Cells["type"].Value.ToString() == vrtype)
            //    {
            //        JiraTicket dd = (JiraTicket)row.DataBoundItem;
            //        dd.type = "";
            //    }
            //    else
            //        vrtype = row.Cells["type"].Value.ToString();
            //}
        }      
    }
}
