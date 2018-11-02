using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace JiraXmlParser
{
    public class XmlParser
    {
        public DateTime xmlDownloadDate = new DateTime();
        //https://stackoverflow.com/questions/642293/how-do-i-read-and-parse-an-xml-file-in-c
        public List<TickectModal> ReadFromFile(string filePath)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNodeList itemNodes = doc.DocumentElement.SelectNodes("/rss/channel/item");
                this.xmlDownloadDate = Convert.ToDateTime(doc.DocumentElement.SelectSingleNode("/rss/channel/build-info/build-date").InnerText);
                List<TickectModal> lstTicketModal = new List<TickectModal>();
                foreach (XmlNode jiraTicket in itemNodes)
                {
                    TickectModal modal = new TickectModal();

                    modal.key = (jiraTicket.SelectNodes("key").Count > 0) ? jiraTicket.SelectNodes("key")[0].InnerText : "";
                    modal.summary = (jiraTicket.SelectNodes("summary").Count > 0) ? jiraTicket.SelectNodes("summary")[0].InnerText : "";
                    modal.link = (jiraTicket.SelectNodes("link").Count > 0) ? jiraTicket.SelectNodes("link")[0].InnerText : "";
                    modal.type = (jiraTicket.SelectNodes("type").Count > 0) ? jiraTicket.SelectNodes("type")[0].InnerText : "";
                    modal.status = (jiraTicket.SelectNodes("status").Count > 0) ? jiraTicket.SelectNodes("status")[0].InnerText : "";
                    modal.assignee = (jiraTicket.SelectNodes("assignee").Count > 0) ? jiraTicket.SelectNodes("assignee")[0].InnerText : "";
                    modal.createdDate = (jiraTicket.SelectNodes("created").Count > 0) ? jiraTicket.SelectNodes("created")[0].InnerText : "";
                    modal.updatedDate = (jiraTicket.SelectNodes("updated").Count > 0) ? jiraTicket.SelectNodes("updated")[0].InnerText : "";
                    modal.aggregatetimeoriginalestimate = (jiraTicket.SelectNodes("aggregatetimeoriginalestimate").Count > 0) ? jiraTicket.SelectNodes("aggregatetimeoriginalestimate")[0].InnerText : "";
                    modal.aggregatetimeremainingestimate = (jiraTicket.SelectNodes("aggregatetimeremainingestimate").Count > 0) ? jiraTicket.SelectNodes("aggregatetimeremainingestimate")[0].InnerText : "";
                    modal.aggregatetimespent = (jiraTicket.SelectNodes("aggregatetimespent").Count > 0) ? jiraTicket.SelectNodes("aggregatetimespent")[0].InnerText : "";
                    lstTicketModal.Add(modal);
                }
                return lstTicketModal;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
