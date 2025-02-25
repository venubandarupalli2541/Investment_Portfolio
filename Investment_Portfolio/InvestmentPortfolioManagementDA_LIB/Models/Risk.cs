using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagementDA_LIB.Models
{
    public class Risk
    {
        public int riskId { get; set; }
        public int portfolioId { get; set; }
        public string riskLevel { get; set; }
        public DateTime analysisDate { get; set; }
    }
}
