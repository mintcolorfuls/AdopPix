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

            builder.Entity<SocialMedia>().HasKey(f => new { f.UserId, f.SocialId });
            builder.Entity<UserFollow>().HasKey(f => new { f.UserId, f.IsFollowing });
            builder.Entity<AuctionTag>().HasKey(f => new { f.TagId, f.AuctionId });
            builder.Entity<WinningBidder>().HasKey(f => new { f.UserId, f.AuctionId });
            builder.Entity<PostLike>().HasKey(f => new { f.UserId, f.PostId });
            builder.Entity<PostTag>().HasKey(f => new { f.TagId, f.PostId });

            builder.Entity<Notification>().HasOne(f => f.User).WithMany(f => f.Notifications)
                    .HasForeignKey(f => f.From);
            builder.Entity<Notification>().HasOne(f => f.User).WithMany(f => f.Notifications)
                    .HasForeignKey(f => f.To);
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<SocialMediaType> SocialMediaTypes { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
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
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PointLogging> PointLoggings { get; set; }
        public DbSet<RankLogging> RankLoggings { get; set; }
        public DbSet<PaymentLogging> PaymentLoggings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
