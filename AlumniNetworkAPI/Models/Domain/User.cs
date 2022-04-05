using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.Domain
{
    public class User
    {

        public User()
        {
            Groups = new HashSet<Group>();
            Topics = new HashSet<Topic>();
            Posts = new HashSet<Post>();
        }

        [Key]
        public int userId { get; set; }

        // Properties
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        [Url]
        [MaxLength(500)]
        public string picture { get; set; }
        [MaxLength(50)]
        public string gender { get; set; }
        [MaxLength(50)]
        public string status { get; set; }
        [MaxLength(50)]
        public string bio { get; set; }
        [MaxLength(50)]
        public string fun_fact { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection <Post> Posts { get; set;}

    }
}
