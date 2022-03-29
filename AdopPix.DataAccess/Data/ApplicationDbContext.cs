using AdopPix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdopPix.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<SocialMedias> SocialMedias { get; set; }
        public DbSet<UserSocial> UserSocials { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }
        public DbSet<AuctionImage> AuctionImages { get; set; }
        public DbSet<ImageType> ImageTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AuctionTag> AuctionTags { get; set; }
        public DbSet<WinningBidder> WinningBidders { get; set; }
        public DbSet<AuctionNotification> AuctionNotifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostView> PostViews { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }
    }
}
