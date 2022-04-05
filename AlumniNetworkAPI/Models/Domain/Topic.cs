using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.Domain
{
    public class Topic
    {
        [Key]
        public int topic_id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cant be more than 50 characters.")]
        public string name { get; set; }
        [Required]
        [MaxLength(500)]
        public string description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
