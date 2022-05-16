using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure.IProcedure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopPix.Procedure
{
    public class PostProcedure : IPostProcedure
    {
        // Dependencies
        private readonly IConfiguration configuration;
        private string connectionString;
        private readonly UserManager<User> userManager;

        // constructor
        public PostProcedure(IConfiguration configuration,UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.connectionString = $"Server={this.configuration["AWSMySQL_Server"]};Database={this.configuration["AWSMySQL_Database"]};user={this.configuration["AWSMySQL_Username"]};password={this.configuration["AWSMySQL_Password"]};";
            this.userManager = userManager;
        }

        // generate Post ID
        private string GeneratePostId()
        {
            string[] dateTime = DateTime.Now.ToString().Split(' ');
            string[] ddmmyyyy = dateTime[0].Split('/');
            string[] hhmmss = dateTime[1].Split(':');
            return $"post-{string.Join("", ddmmyyyy)}{string.Join("", hhmmss)}";
        }

        public async Task CreateAsync(Post entity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Post_Create";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PostId", MySqlDbType.VarChar).Value = GeneratePostId();
                    command.Parameters.Add("@Title", MySqlDbType.VarChar).Value = entity.Title;
                    command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = entity.Description;
                    command.Parameters.Add("@UserId", MySqlDbType.VarChar).Value = entity.UserId;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = entity.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }
        public async Task CreateImageAsync(PostImage entity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Post_UploadImage";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PostId", MySqlDbType.VarChar).Value = GeneratePostId();
                    command.Parameters.Add("@ImageId", MySqlDbType.VarChar).Value = entity.ImageId;
                    command.Parameters.Add("@Created", MySqlDbType.DateTime).Value = entity.Created;

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
        }

        public async Task<List<Post>> FindAllAsync()
        {
            List<Post> posts = new List<Post>();
            Post post = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Post_Index_PostDetail";
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        post = new Post
                        {
                            PostId = reader["PostId"].ToString(),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            UserId = reader["UserId"].ToString(),
                            // ตัวแปร เวลา จะต้อง Convert เป็น datetime ก่อนแล้วเอามาแปลงเป็น string
                            Created = Convert.ToDateTime(reader["Created"])
                        };
                        posts.Add(post);
                        post = null;
                    }
                    await connection.CloseAsync();
                }
            }
            return posts;
        }

        public async Task<PostImage> FindImageByPostIdAsync(string postId)
        {
            // List<Post> images = new List<Post>();
            PostImage image = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Post_Index_Image";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PostId", MySqlDbType.VarChar).Value = postId;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        image = new PostImage
                        {
                            ImageId = reader["ImageId"].ToString()
                        };
                        // images.Add(image);
                        // image = null;
                    }
                    await connection.CloseAsync();
                }
            }
            return image;
        }

        public async Task<PostViewModel> FindByPostId(string postId)
        {
            PostViewModel postViewModel = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Find_Post_By_Id";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@PostId", MySqlDbType.VarChar).Value = postId;

                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        postViewModel = new PostViewModel
                        {
                            UserId = reader["UserId"].ToString(),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            ImageName = reader["ImageId"].ToString()
                        };
                        
                    }
                    await connection.CloseAsync();
                }
            }
            return postViewModel;
        }

        public Task UpdateAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
