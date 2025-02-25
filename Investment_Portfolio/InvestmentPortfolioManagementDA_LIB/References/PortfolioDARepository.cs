using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentPortfolioManagementDA_LIB.Models;

namespace InvestmentPortfolioManagementDA_LIB.References
{
    class PortfolioDARepository : IRepository<Portfolio>
    {
        SqlConnection con;

        public PortfolioDARepository()
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

        public bool Add(Portfolio entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Portfolio VALUES(@p1,@p2,@p3, @p4)", con);
                cmd.Parameters.AddWithValue("@p1", entity.portfolioId);
                cmd.Parameters.AddWithValue("@p2", entity.userId);
                cmd.Parameters.AddWithValue("@p3", entity.portfolioName);
                cmd.Parameters.AddWithValue("@p4", entity.creationDate);
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

        public bool Delete(Portfolio entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from Delete Where portfolioId=@p1", con);
                cmd.Parameters.AddWithValue("@p1", entity.portfolioId);

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

        public Portfolio Get(object id)
        {
            string UserID = (string)id;     // unboxing
            List<Portfolio> users = GetAll();
            Portfolio user = users.Where(d => d.portfolioId.ToString() == UserID).FirstOrDefault();  // LINQ Syntax
            return user;
        }

        public List<Portfolio> GetAll()
        {
            List<Portfolio> users = new List<Portfolio>();
            SqlCommand cmd = new SqlCommand("Select * from Portfolio", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Portfolio d = new Portfolio()
                {
                    portfolioId = Convert.ToInt32(sqldr[0]),
                    userId = Convert.ToInt32(sqldr[1]),
                    portfolioName = sqldr[2].ToString(),
                    creationDate = Convert.ToDateTime(sqldr[3])
                };
                users.Add(d);
            }
            sqldr.Close();
            return users;
        }

        public bool Update(Portfolio entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update DOCTOR Set userId=@p2, portfolioName=@p3, creationDate=@p4 where portfolioId=@p1", con);

                cmd.Parameters.AddWithValue("@p1", entity.portfolioId);
                cmd.Parameters.AddWithValue("@p2", entity.userId);
                cmd.Parameters.AddWithValue("@p3", entity.portfolioName);
                cmd.Parameters.AddWithValue("@p4", entity.creationDate);

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
