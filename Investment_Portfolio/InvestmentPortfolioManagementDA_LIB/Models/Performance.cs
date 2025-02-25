using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagementDA_LIB.Models
{
    public class Performance
    {
        public int performanceId { get; set; }
        public int assetId { get; set; }
        public double currentValue { get; set; }
        public double profitLoss { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
