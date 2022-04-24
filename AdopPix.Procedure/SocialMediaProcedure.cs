using AdopPix.Models;
using AdopPix.Procedure.IProcedure;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AdopPix.Procedure
{
    public class SocialMediaProcedure : ISocialMediaProcedure
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        public SocialMediaProcedure(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = $"Server={this.configuration["AWSMySQL_Server"]};Database={this.configuration["AWSMySQL_Database"]};user={this.configuration["AWSMySQL_Username"]};password={this.configuration["AWSMySQL_Password"]}";
        }
        public async Task CreateAsync(SocialMedia entity)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SocialMedia_Create";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = entity.UserId;
                    command.Parameters.Add("@SocialId", MySqlDbType.Int64).Value = entity.SocialId;
                    command.Parameters.Add("@Url", MySqlDbType.VarChar).Value = entity.Url;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = entity.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }

        public async Task DeleteAsync(SocialMedia entity)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SocialMedia_Delete";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = entity.UserId;
                    command.Parameters.Add("@Url", MySqlDbType.VarChar).Value = entity.Url;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<List<SocialMedia>> FindByIdAsync(string userId)
        {
            List<SocialMedia> result = new List<SocialMedia>();
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SocialMedia_FindById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = userId;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        SocialMedia socialMedia = new SocialMedia
                        {
                            UserId = reader["UserId"].ToString(),
                            SocialId = Convert.ToInt32(reader["SocialId"]),
                            Url = reader["Url"].ToString(),
                            Created = Convert.ToDateTime(reader["Created"])
                        };
                        result.Add(socialMedia);
                    }
                    await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<SocialMedia> FindByUrlAsync(string userId, string url)
        {
            SocialMedia result = null;
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SocialMedia_FindByUrl";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = userId;
                    command.Parameters.Add("@Url", MySqlDbType.VarChar).Value = url;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = new SocialMedia
                        {
                            UserId = reader["UserId"].ToString(),
                            SocialId = Convert.ToInt32(reader["SocialId"]),
                            Url = reader["Url"].ToString(),
                            Created = Convert.ToDateTime(reader["Created"])
                        };
                    }
                    await connection.CloseAsync();
                }
            }
            return result;
        }
    }
}
