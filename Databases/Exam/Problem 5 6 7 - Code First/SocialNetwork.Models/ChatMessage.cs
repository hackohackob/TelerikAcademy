using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }

        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime SendOn { get; set; }

        public DateTime SeenOn { get; set; }
    }
}
