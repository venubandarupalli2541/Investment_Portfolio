using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentPortfolioManagementDA_LIB.Models;

namespace InvestmentPortfolioManagementDA_LIB.References
{
    public class userPortfolioRepo : IRepository<User_portfolio>
    {
        SqlConnection con;

        public userPortfolioRepo()
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

        public bool Add(User_portfolio entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO User_portfolio VALUES(@p1,@p2,@p3, @p4, @p5)", con);
                cmd.Parameters.AddWithValue("@p1", entity.UserId);
                cmd.Parameters.AddWithValue("@p2", entity.username);
                cmd.Parameters.AddWithValue("@p3", entity.password);
                cmd.Parameters.AddWithValue("@p4", entity.email);
                cmd.Parameters.AddWithValue("@p5", entity.role);
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

        public bool Delete(User_portfolio entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from User_portfolio Where UserId=@p1", con);
                cmd.Parameters.AddWithValue("@p1", entity.UserId);

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

        

        public User_portfolio Get(object id)
        {
            string UserID = (string)id;     // unboxing
            List<User_portfolio> users = GetAll();
            User_portfolio user = users.Where(d => d.UserId.ToString() == UserID).FirstOrDefault();  // LINQ Syntax
            return user;
        }

        public List<User_portfolio> GetAll()
        {
            List<User_portfolio> users = new List<User_portfolio>();
            SqlCommand cmd = new SqlCommand("Select * from User_portfolio", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                User_portfolio d = new User_portfolio()
                {

                    UserId = Convert.ToInt32(sqldr[0]),
                    username = sqldr[1].ToString(),
                    email = sqldr[2].ToString(),
                    password = sqldr[3].ToString()
                };
                users.Add(d);
            }
            sqldr.Close();
            return users;
        }

        public bool Update(User_portfolio entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update User_portfolio Set username=@p2, password=@p3, email=@p4, role=@p5 where UserId=@p1", con);

                cmd.Parameters.AddWithValue("@p1", entity.UserId);
                cmd.Parameters.AddWithValue("@p2", entity.username);
                cmd.Parameters.AddWithValue("@p3", entity.password);
                cmd.Parameters.AddWithValue("@p4", entity.email);
                cmd.Parameters.AddWithValue("@p5", entity.role);

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