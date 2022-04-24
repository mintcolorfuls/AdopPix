using AdopPix.Models;
using AdopPix.Procedure.IProcedure;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace AdopPix.Procedure
{
    public class PaymentLoggingProcedure : IPaymentLoggingProcedure
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        public PaymentLoggingProcedure(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = $"Server={this.configuration["AWSMySQL_Server"]};Database={this.configuration["AWSMySQL_Database"]};user={this.configuration["AWSMySQL_Username"]};password={this.configuration["AWSMySQL_Password"]}";
        }

        public async Task CreateAsync(PaymentLogging entity)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "PaymentLogging_Create";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = entity.UserId;
                    command.Parameters.Add("@Charge", MySqlDbType.VarChar).Value = entity.Charge;
                    command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = entity.Name;
                    command.Parameters.Add("@Amount", MySqlDbType.Decimal).Value = entity.Amount;
                    command.Parameters.Add("@Currency", MySqlDbType.VarChar).Value = entity.Currency;
                    command.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = entity.Brand;
                    command.Parameters.Add("@Financing", MySqlDbType.VarChar).Value = entity.Financing;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = entity.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }
    }
}

