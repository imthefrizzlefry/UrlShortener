using System.Configuration;
using System.Data.SqlClient;

namespace CommonFramework
{
    public static class DataAccess
    {

        //connection string is constructed from values in the config file
        private static string GetConnectionString()
        {
            string temp = ConfigurationManager.AppSettings["ConnectionString"];
            return temp;
        }
        public static void InsertUrl(string Url)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO UrlTable (Url) VALUES (@Url)");
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Url", Url);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static string RetrieveUrl(int id)
        {
            string url = "";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
                    url = "No rows found.";
                }
                reader.Close();
            }

            return url;
        }

        public static string RetrieveUrl(string urlCode)
        {
            int id = UrlMinimizer.Decode(urlCode);

            string url = "";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
                    url = "No rows found.";
                }
                reader.Close();
            }

            return url;
        }

        public static string RemoveRecord(int id)
        {
            string urlRemoved = "";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("DELETE FROM UrlTable WHERE Id = " + id.ToString());
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        urlRemoved = reader.GetSqlString(1).ToString();
                    }
                }
                else
                {
                    urlRemoved = "No rows found.";
                }
                reader.Close();
            }

            return urlRemoved;
        }

        //public static UrlData RetrieveUrlData(string urlCode)
        //{
        //    UrlData urlRecord = new UrlData();
        //    int id = UrlMinimizer.Decode(urlCode);

        //    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        //    {
        //        SqlDataReader reader;
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM UrlTable WHERE Id = " + id.ToString());
        //        cmd.Connection = connection;
        //        connection.Open();
        //        reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                urlRecord.UrlId = reader.GetInt32(reader.GetOrdinal("Id"));
        //                urlRecord.Url = reader.GetString(reader.GetOrdinal("Url"));
        //                urlRecord.DateCreated = reader.GetDateTime(reader.GetOrdinal("Created"));
        //            }
        //        }
        //        else
        //        {
        //            urlRecord = null;
        //        }
        //        reader.Close();
        //    }

        //    return urlRecord;
        //}

        //public static List<UrlData> RetrieveAllUrlData()
        //{
        //    List<UrlData> allRecords = new List<UrlData>();


        //    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        //    {

        //        SqlDataReader reader;
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM UrlTable");
        //        cmd.Connection = connection;
        //        connection.Open();
        //        reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                //create an instance of urlRecord
        //                UrlData urlRecord = new UrlData();

        //                //add all data from the record into the UrlRecord stub
        //                urlRecord.UrlId = reader.GetInt32(reader.GetOrdinal(""));
        //                urlRecord.Url = reader.GetString(reader.GetOrdinal(""));
        //                urlRecord.DateCreated = reader.GetDateTime(reader.GetOrdinal(""));
        //                //Add record to the list to be returned
        //                allRecords.Add(urlRecord);
        //            }
        //        }

        //        reader.Close();
        //    }

        //    return allRecords;
        //}

        public static int GetRecordCount()
        {
            int recordCount = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("SELECT * FROM UrlTable");
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        recordCount++;
                    }
                }
                else
                {
                    recordCount = -1;
                }
                reader.Close();
            }

            return recordCount;
        }

        public static int GetMostRecentRecordId()
        {
            int mostRecentRecord = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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

        //public static UrlData GetMostRecentRecord()
        //{
        //    UrlData mostRecentRecord = new UrlData();

        //    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
        //    {
        //        SqlDataReader reader;
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM UrlTable WHERE Id = (SELECT max(Id) FROM UrlTable)");
        //        cmd.Connection = connection;
        //        connection.Open();
        //        reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                mostRecentRecord.UrlId = reader.GetInt32(reader.GetOrdinal("Id"));
        //                mostRecentRecord.Url = reader.GetString(reader.GetOrdinal("Url"));
        //                mostRecentRecord.DateCreated = reader.GetDateTime(reader.GetOrdinal("Created"));
        //            }
        //        }
        //        reader.Close();
        //    }

        //    return mostRecentRecord;
        //}
    }
    
}
