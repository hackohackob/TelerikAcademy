﻿namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserProfile
    {
        private ICollection<Image> images;
        private ICollection<Post> taggedIn;

        public UserProfile()
        {
            this.images = new HashSet<Image>();
            this.taggedIn = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique =true)]
        [MinLength(4)]
        [MaxLength(20)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Post> TaggedIn
        {
            get { return this.taggedIn; }
            set { this.taggedIn = value; }
        }
    }
}
