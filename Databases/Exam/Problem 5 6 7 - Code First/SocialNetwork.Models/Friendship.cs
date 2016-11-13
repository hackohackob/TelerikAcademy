namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FirstUserId { get; set; }

        public virtual UserProfile FirstUser { get; set; }

        [Required]
        public int SecondUserId { get; set; }

        public virtual UserProfile SecondUser { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? ApprovedOn { get; set; }
    }
}
