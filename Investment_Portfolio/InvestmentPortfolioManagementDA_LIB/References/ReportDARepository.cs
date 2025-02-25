using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentPortfolioManagementDA_LIB.Models;

namespace InvestmentPortfolioManagementDA_LIB.References
{
    class ReportDARepository : IRepository<Report>
    {
        SqlConnection con;

        public ReportDARepository()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }
        public string ConnectionString
        {
            get
            {
                return "Data Source=LTIN453342\\SQLEXPRESS;Initial Catalog=Investment_portfolio;Integrated Security=True";
            }
        }

        public bool Add(Report entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Report VALUES(@p1,@p2,@p3)", con);
                cmd.Parameters.AddWithValue("@p1", entity.reportId);
                cmd.Parameters.AddWithValue("@p2", entity.reportType);
                cmd.Parameters.AddWithValue("@p3", entity.generatedDate);
                
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }

        public bool Delete(Report entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from Asset Where reportId=@p1", con);
                cmd.Parameters.AddWithValue("@p1", entity.reportId);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }

        public Report Get(object id)
        {
            string UserID = (string)id;     // unboxing
            List<Report> users = GetAll();
            Report user = users.Where(d => d.reportId.ToString() == UserID).FirstOrDefault();  // LINQ Syntax
            return user;
        }

        public List<Report> GetAll()
        {
            List<Report> users = new List<Report>();
            SqlCommand cmd = new SqlCommand("Select * from Report", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Report d = new Report()
                {
                    reportId = Convert.ToInt32(sqldr[0]),
                    generatedDate = Convert.ToDateTime(sqldr[2]),
                    reportType = sqldr[1].ToString(),
                    
                };
                users.Add(d);
            }
            sqldr.Close();
            return users;
        }

        public bool Update(Report entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update Report Set reportType=@p2, generatedDate=@p3 where reportId=@p1", con);

                cmd.Parameters.AddWithValue("@p1", entity.reportId);
                cmd.Parameters.AddWithValue("@p2", entity.reportType);
                cmd.Parameters.AddWithValue("@p3", entity.generatedDate);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update Operation Failed -" + ex.Message);
                b = false;
            }
            return b;
        }


    }
}
