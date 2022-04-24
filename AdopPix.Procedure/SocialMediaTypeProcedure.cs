using AdopPix.Models;
using AdopPix.Procedure.IProcedure;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopPix.Procedure
{
    public class SocialMediaTypeProcedure : ISocialMediaTypeProcedure
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        public SocialMediaTypeProcedure(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = $"Server={this.configuration["AWSMySQL_Server"]};Database={this.configuration["AWSMySQL_Database"]};user={this.configuration["AWSMySQL_Username"]};password={this.configuration["AWSMySQL_Password"]}";
        }
        public async Task<Dictionary<int, string>> FindAsync()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SocialMediaType_Find";
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(Convert.ToInt32(reader["SocialId"]), reader["Title"].ToString());
                    }
                    await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<SocialMediaType> FindByNameAsync(string name)
        {
            SocialMediaType result = null;
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SocialMediaType_FindByName";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Title", MySqlDbType.VarChar).Value = name;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = new SocialMediaType
                        {
                            SocialId = Convert.ToInt32(reader["SocialId"]),
                            Title = reader["Title"].ToString(),
                        };
                    }
                    await connection.CloseAsync();
                }
            }
            return result;
        }
    }
}
