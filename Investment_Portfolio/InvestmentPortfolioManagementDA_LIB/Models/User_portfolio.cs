using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagementDA_LIB.Models
{
    public class User_portfolio
    {
        public int UserId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int email { get; set; }
        public int role { get; set; }
    }
}
