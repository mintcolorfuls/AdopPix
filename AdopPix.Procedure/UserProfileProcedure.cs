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
    public class UserProfileProcedure : IUserProfileProcedure
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        public UserProfileProcedure(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = $"Server={this.configuration["AWSMySQL_Server"]};Database={this.configuration["AWSMySQL_Database"]};user={this.configuration["AWSMySQL_Username"]};password={this.configuration["AWSMySQL_Password"]}";
        }

        public async Task CreateAsync(UserProfile entity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UserProfile_Create";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = entity.UserId;
                    command.Parameters.Add("@Gender", MySqlDbType.LongText).Value = entity.Gender;
                    command.Parameters.Add("@AvatarName", MySqlDbType.LongText).Value = entity.AvaterName;
                    command.Parameters.Add("@CoverName", MySqlDbType.LongText).Value = entity.CoverName;
                    command.Parameters.Add("@Fname", MySqlDbType.LongText).Value = entity.Fname;
                    command.Parameters.Add("@Lname", MySqlDbType.LongText).Value = entity.Lname;
                    command.Parameters.Add("@Money", MySqlDbType.Decimal).Value = entity.Money;
                    command.Parameters.Add("@BirthDate", MySqlDbType.DateTime).Value = entity.BirthDate;
                    command.Parameters.Add("@Poin", MySqlDbType.Decimal).Value = entity.Point;
                    command.Parameters.Add("@Ran", MySqlDbType.Decimal).Value = entity.Rank;
                    command.Parameters.Add("@Descr", MySqlDbType.LongText).Value = entity.Description;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = entity.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<UserProfile> FindByIdAsync(string userId)
        {
            UserProfile userProfile = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UserProfile_FindById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = userId;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userProfile = new UserProfile
                        {
                            UserId = reader["UserId"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            AvaterName = reader["AvaterName"].ToString(),
                            CoverName = reader["CoverName"].ToString(),
                            Fname = reader["Fname"].ToString(),
                            Lname = reader["Lname"].ToString(),
                            Money = Convert.ToDecimal(reader["Money"].ToString()),
                            BirthDate = Convert.ToDateTime(reader["BirthDate"].ToString()),
                            Point = Convert.ToDecimal(reader["Point"].ToString()),
                            Rank = Convert.ToDecimal(reader["Rank"].ToString()),
                            Description = reader["Description"].ToString()
                        };
                    }
                    await connection.CloseAsync();
                }
            }
            return userProfile;
        }

        public async Task UpdateAsync(UserProfile entity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UserProfile_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = entity.UserId;
                    command.Parameters.Add("@AvatarName", MySqlDbType.LongText).Value = entity.AvaterName;
                    command.Parameters.Add("@CoverName", MySqlDbType.LongText).Value = entity.CoverName;
                    command.Parameters.Add("@Fname", MySqlDbType.LongText).Value = entity.Fname;
                    command.Parameters.Add("@Lname", MySqlDbType.LongText).Value = entity.Lname;
                    command.Parameters.Add("@Descr", MySqlDbType.LongText).Value = entity.Description;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }
    }
}
