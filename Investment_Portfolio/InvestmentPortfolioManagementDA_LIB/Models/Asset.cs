using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagementDA_LIB.Models
{
    public class Asset
    {
        public int assetId { get; set; }
        public int portfolioId { get; set; }
        public string assetType { get; set; }
        public string assetName { get; set; }
        public int quantity { get; set; }
        public decimal purchasePrice { get; set; }

    }
}
