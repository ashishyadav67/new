using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace ProjectOne.Services
{
    public class DbConn
    {
        public IConfiguration Config { get; }

        public string? conStr { get; set; }
        public DbConn(IConfiguration _Config)
        {
            Config = _Config;
            conStr = Config.GetConnectionString("dbConn");
        }
        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter(query, new SqlConnection(conStr)))
            {
                //if (con.State == 0)
                //{
                //    con.Open();
                //}


                sda.Fill(dt);

            }
            return dt;
        }
        public string GetDataReader(string query)
        {
            string str = null ;
            SqlDataReader dr;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                if (con.State == 0)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    str = dr[0].ToString();
                }


                return str;

            }


        }
    }
}
