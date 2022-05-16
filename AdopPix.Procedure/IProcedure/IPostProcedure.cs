using AdopPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface IPostProcedure
    {
        Task CreateAsync(Post entity);
        Task CreateImageAsync(PostImage entity);
        Task<Post> FindByPostIdAsync(string postId);
        Task<PostImage> FindImageByPostIdAsync(string postId);
        Task UpdateAsync(Post entity);
        Task DeleteAsync(Post entity);
    }
}
