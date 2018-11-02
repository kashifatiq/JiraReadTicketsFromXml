using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraXmlParser
{
    public class TickectModal
    {
        public string key = "";
        public string summary = "";
        public string link = "";
        public string type = "";
        public string status = "";
        public string assignee = "";
        public string createdDate = "";
        public string updatedDate = "";
        public string aggregatetimeoriginalestimate = "";
        public string aggregatetimeremainingestimate = "";
        public string aggregatetimespent = "";
        public DateTime xmlDownloadDate = DateTime.Now;
        public bool IsDeleted = false;
    }
}
