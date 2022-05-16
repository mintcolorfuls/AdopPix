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
    public class AuctionProcedure : IAuctionProcedure
    {
        private readonly IConfiguration configuration;
        private string connectionString;
        public AuctionProcedure(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = $"Server={this.configuration["AWSMySQL_Server"]};Database={this.configuration["AWSMySQL_Database"]};user={this.configuration["AWSMySQL_Username"]};password={this.configuration["AWSMySQL_Password"]}";
        }
        private string GenerateAuctionId()
        {
            string[] dateTime = DateTime.Now.ToString().Split(' ');
            string[] ddmmyyyy = dateTime[0].Split('/');
            string[] hhmmss = dateTime[1].Split(':');
            return $"post-{string.Join("", ddmmyyyy)}{string.Join("", hhmmss)}";
        }
        public async Task CreateAsync(Auction auction)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                var generateAuctionId = GenerateAuctionId();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    
                    command.CommandText = "Auction_Create";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@AuctionId", MySqlDbType.VarChar).Value = auction.AuctionId;
                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = auction.UserId;
                    command.Parameters.Add("@Title", MySqlDbType.VarChar).Value = auction.Title;
                    command.Parameters.Add("@HourId", MySqlDbType.Int32).Value = auction.HourId;
                    command.Parameters.Add("@OpeningPrice", MySqlDbType.Decimal).Value = auction.OpeningPrice;
                    command.Parameters.Add("@HotClose", MySqlDbType.Decimal).Value = auction.HotClose;
                    command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = auction.Description;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = auction.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();

                    
                }

            }
        }

        public Task DeleteAsync(Auction auction)
        {
            throw new NotImplementedException();
        }

        public Task FindAll(Auction auction)
        {
            throw new NotImplementedException();
        }

        public async Task<Auction> FindByIdAsync(string auctionId)
        {
            Auction auction = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AuctionId_FindById";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@AuctionId", MySqlDbType.VarChar).Value = auctionId;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        auction = new Auction
                        {
                            AuctionId = reader["AuctionId"].ToString(),
                            UserId = reader["UserId"].ToString(),
                            Title = reader["Title"].ToString(),
                            HourId = Convert.ToInt32(reader["HourId"].ToString()),
                            Created = Convert.ToDateTime(reader["Created"].ToString()),
                            OpeningPrice = Convert.ToDecimal(reader["OpeningPrice"].ToString()),
                            HotClose = Convert.ToDecimal(reader["HotClose"].ToString()),
                            Description = reader["Description"].ToString()

                    };
                    }
                    await connection.CloseAsync();
                }
            }
            return auction;
        }

        public Task UpdateAsync(Auction auction)
        {
            throw new NotImplementedException();
        }

        public async Task CreateImageAsync(AuctionImage auctionImage)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "AuctionImage_Create";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ImageId", MySqlDbType.VarChar).Value = GenerateAuctionId();
                    command.Parameters.Add("@AuctionId", MySqlDbType.VarChar).Value = auctionImage.AuctionId;
                    command.Parameters.Add("@ImageTypeId", MySqlDbType.Int32).Value = 1;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = auctionImage.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }
    }
}
