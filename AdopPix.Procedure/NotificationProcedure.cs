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
    public class NotificationProcedure : INotificationProcedure
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        public NotificationProcedure(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = $"Server={this.configuration["AWSMySQL_Server"]};Database={this.configuration["AWSMySQL_Database"]};user={this.configuration["AWSMySQL_Username"]};password={this.configuration["AWSMySQL_Password"]}";
        }
        public async Task CreateAsync(Notification entity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using(MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Notifications_Create";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@FromId", MySqlDbType.VarChar).Value = entity.From;
                    command.Parameters.Add("@ToId", MySqlDbType.VarChar).Value = entity.To;
                    command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = entity.Description;
                    command.Parameters.Add("@RedirectToUrl", MySqlDbType.VarChar).Value = entity.RedirectToUrl;
                    command.Parameters.Add("@IsOpen", MySqlDbType.VarChar).Value = entity.isOpen;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = entity.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<List<Notification>> FindByUserIdAsync(string userId)
        {
            List<Notification> notifications = new List<Notification>();
            Notification notification = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Notifications_FindByUserId";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = userId;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        notification = new Notification
                        {
                            NotiId = Convert.ToInt32(reader["NotiId"].ToString()),
                            From = reader["From"].ToString(),
                            To = reader["From"].ToString(),
                            Description = reader["Description"].ToString(),
                            RedirectToUrl = reader["RedirectToUrl"].ToString(),
                            isOpen = Convert.ToBoolean(reader["isOpen"]),
                            Created = Convert.ToDateTime(reader["Created"])
                        };
                        notifications.Add(notification);
                        notification = null;
                    }
                    await connection.CloseAsync();
                }
            }
            return notifications;
        }
    }
}
