using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagementDA_LIB.Models
{
    public class Portfolio
    {
        public int portfolioId { get; set; }
        public int userId { get; set; }
        public varchar portfoliaName { get; set; }
        public DateTime creationDate { get; set; }

    }
}
