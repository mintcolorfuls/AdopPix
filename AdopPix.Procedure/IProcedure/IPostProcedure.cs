using AdopPix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface IPostProcedure
    {
        Task CreateAsync(Post entity);
        Task CreateImageAsync(PostImage entity);
        Task<List<Post>> FindAllAsync();
        Task<Post> FindByPostId(string postId);
        Task<PostImage> FindImageByPostIdAsync(string postId);
        Task UpdateAsync(Post entity);
        Task DeleteAsync(Post entity);
    }
}
