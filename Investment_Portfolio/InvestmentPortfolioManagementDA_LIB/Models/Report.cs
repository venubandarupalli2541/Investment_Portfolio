using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagementDA_LIB.Models
{
    public class Report
    {
        public int ReportId { set; get; } 
        public string ReportType { set; get; }
        public DateTime GeneratedDate { set; get; }
    }
}
