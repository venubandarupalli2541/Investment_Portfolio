﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagementDA_LIB.Models
{
    public class Report
    {
        public int reportId { set; get; }
        public string reportType { set; get; }
        public DateTime generatedDate { set; get; }
    }
}
