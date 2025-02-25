using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentPortfolioManagementDA_LIB.Models;

namespace InvestmentPortfolioManagementDA_LIB.References
{
    class AssetDARepository : IRepository<Asset>
    {
        SqlConnection con;

        public AssetDARepository()
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

        public bool Add(Asset entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Asset VALUES(@p1,@p2,@p3, @p4, @p5, @p6)", con);
                cmd.Parameters.AddWithValue("@p1", entity.assetId);
                cmd.Parameters.AddWithValue("@p2", entity.portfolioId);
                cmd.Parameters.AddWithValue("@p3", entity.assetType);
                cmd.Parameters.AddWithValue("@p4", entity.assetName);
                cmd.Parameters.AddWithValue("@p5", entity.quantity);
                cmd.Parameters.AddWithValue("@p6", entity.purchasePrice);
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

        public bool Delete(Asset entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from Asset Where AssetId=@p1", con);
                cmd.Parameters.AddWithValue("@p1", entity.assetId);

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

        public Asset Get(object id)
        {
            string UserID = (string)id;     // unboxing
            List<Asset> users = GetAll();
            Asset user = users.Where(d => d.assetId.ToString() == UserID).FirstOrDefault();  // LINQ Syntax
            return user;
        }

        public List<Asset> GetAll()
        {
            List<Asset> users = new List<Asset>();
            SqlCommand cmd = new SqlCommand("Select * from Asset", con);
            SqlDataReader sqldr = cmd.ExecuteReader();
            while (sqldr.Read())
            {
                Asset d = new Asset()
                {
                    assetId = Convert.ToInt32(sqldr[0]),
                    portfolioId = Convert.ToInt32(sqldr[1]),
                    assetType = sqldr[2].ToString(),
                    assetName = sqldr[3].ToString(),
                    quantity = Convert.ToInt32(sqldr[4]),
                    purchasePrice = Convert.ToDecimal(sqldr[5])
                };
                users.Add(d);
            }
            sqldr.Close();
            return users;
        }

        public bool Update(Asset entity)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand("Update Asset Set portfolioId=@p2, assetType=@p3, assetName=@p4,quantity=@p5, purchasePrice=@p6  where assetId=@p1", con);

                cmd.Parameters.AddWithValue("@p1", entity.assetId);
                cmd.Parameters.AddWithValue("@p2", entity.portfolioId);
                cmd.Parameters.AddWithValue("@p3", entity.assetType);
                cmd.Parameters.AddWithValue("@p4", entity.assetName);
                cmd.Parameters.AddWithValue("@p5", entity.quantity);
                cmd.Parameters.AddWithValue("@p6", entity.purchasePrice);

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
