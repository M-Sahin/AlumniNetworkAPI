using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AlumniNetworkAPI.Models.Domain
{
    public class Group
    {
        [Key]
        public int group_id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cant be more than 50 characters.")]
        public string name { get; set; }
        [Required]
        [MaxLength(500)]
        public string description { get; set; }

        [Required]
        public bool isPrivate { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<GroupUser> GroupUsers { get; set; }

    }
}
