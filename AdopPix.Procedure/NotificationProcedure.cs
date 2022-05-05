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
                    command.CommandText = "Notification_Create";
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
    }
}
