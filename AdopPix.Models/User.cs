using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AdopPix.Models
{
    public class User : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
        public List<UserSocial> UserSocials { get; set; }
        public List<Auction> Auctions { get; set; }
        public List<AuctionBid> AuctionBids { get; set; }
        public List<WinningBidder> WinningBidders { get; set; }
        public List<AuctionNotification> AuctionNotifications { get; set; }
        public List<Post> Posts { get; set; }
        public List<PostLike> PostLikes { get; set; }
        public List<PostComment> PostComments { get; set; }
        public List<PostView> PostViews { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<UserFollow> UserFollows { get; set; }
    }
}
