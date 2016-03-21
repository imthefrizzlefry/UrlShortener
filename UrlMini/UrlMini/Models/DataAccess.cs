using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace UrlMini.Models
{
    public static class DataAccess
    {

        //connection string is constructed from values in the config file
        private static string _connectionString
        {
            get
            {
                string temp = ConfigurationManager.AppSettings["ConnectionString"];
                return temp;
            }
        }

        public static void InsertUrl(string Url)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO UrlTable (Url) VALUES (@Url)");
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Url", Url);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static string RetrieveUrl(string urlCode)
        {
            int id = UrlMinimizer.Decode(urlCode);

            string url = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("SELECT * FROM UrlTable WHERE Id = " + id.ToString());
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        url = reader.GetSqlString(1).ToString();
                    }
                }
                else
                {
                    url = "NotFound";
                }
                reader.Close();
            }

            return url;
        }

        public static int GetMostRecentRecordId()
        {
            int mostRecentRecord = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("SELECT Id FROM UrlTable WHERE Id = (SELECT max(Id) FROM UrlTable)");
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mostRecentRecord = reader.GetInt32(reader.GetOrdinal("Id"));
                    }
                }
                reader.Close();
            }

            return mostRecentRecord;
        }
        
    }
}