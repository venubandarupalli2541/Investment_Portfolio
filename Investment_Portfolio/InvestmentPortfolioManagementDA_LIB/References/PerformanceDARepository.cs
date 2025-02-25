using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentPortfolioManagementDA_LIB.Models;

namespace InvestmentPortfolioManagementDA_LIB.References
{
    class PerformanceDARepository : IRepository<Performance>
    {
        SqlConnection con;

        public PerformanceDARepository()
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

        public bool Add(Performance entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Performance VALUES(@p1,@p2,@p3, @p4, @p5)", con);
                cmd.Parameters.AddWithValue("@p1", entity.performanceId);
                cmd.Parameters.AddWithValue("@p2", entity.assetId);
                cmd.Parameters.AddWithValue("@p3", entity.currentValue);
                cmd.Parameters.AddWithValue("@p4", entity.profitLoss);
                cmd.Parameters.AddWithValue("@p4", entity.lastUpdated);
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

        public bool Delete(Performance entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from Performance Where PerformanceId=@p1", con);
                cmd.Parameters.AddWithValue("@p1", entity.performanceId);

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

        public Performance Get(object id)
        {
            string UserID = (string)id;     // unboxing
            List<Performance> users = GetAll();
            Performance user = users.Where(d => d.performanceId.ToString() == UserID).FirstOrDefault();  // LINQ Syntax
            return user;
        }

        public List<Performance> GetAll()
        {
            List<Performance> users = new List<Performance>();
            SqlCommand cmd = new SqlCommand("Select * from Performance", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Performance d = new Performance()
                {
                    performanceId = Convert.ToInt32(sqldr[0]),
                    assetId = Convert.ToInt32(sqldr[1]),
                    currentValue = Convert.ToInt32(sqldr[2]),
                    profitLoss = Convert.ToInt32(sqldr[3]),
                    lastUpdated = Convert.ToDateTime(sqldr[4])
                };
                users.Add(d);
            }
            sqldr.Close();
            return users;
        }

        public bool Update(Performance entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update Performance Set assetId=@p2, currentValue=@p3, profitLoss=@p4, lastUpdated=@p5 where performanceId=@p1", con);

                cmd.Parameters.AddWithValue("@p1", entity.performanceId);
                cmd.Parameters.AddWithValue("@p2", entity.assetId);
                cmd.Parameters.AddWithValue("@p3", entity.currentValue);
                cmd.Parameters.AddWithValue("@p4", entity.profitLoss);
                cmd.Parameters.AddWithValue("@p4", entity.lastUpdated);

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
