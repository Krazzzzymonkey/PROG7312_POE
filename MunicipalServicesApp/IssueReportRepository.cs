using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ST10067040
// to be implemented

namespace MunicipalServicesApp
{

    public class IssueReportRepository
    {
        private readonly string _connectionString;

        public IssueReportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

     
        public void SaveIssueReport(string location, string category, string description, string attachments)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO IssueReports (Location, Category, Description, Attachments) VALUES (@Location, @Category, @Description, @Attachments)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Attachments", attachments); 

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}


