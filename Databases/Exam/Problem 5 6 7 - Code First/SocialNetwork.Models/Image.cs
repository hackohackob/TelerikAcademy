namespace SocialNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Url { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        [Required]
        public int UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get;set;}
    }
}
