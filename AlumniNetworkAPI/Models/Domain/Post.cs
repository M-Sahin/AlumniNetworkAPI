using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniNetworkAPI.Models.Domain
{
    public class Post
    {
       
        [Key]
        public int Post_Id { get; set; }
        [MaxLength(50, ErrorMessage = "Title cant be longer than 50 characters.")]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(500, ErrorMessage = "Text cant be longer than 500 characters.")]
        public string Body { get; set; }

        public DateTime TimeStamp { get; set; }
        [Required]
        public User SenderUserId { get; set; }

        public Post? ReplyParentId { get; set; }

        public User? TargetUserId { get; set; }
        
        public Group? TargetGroupId { get; set; }
        
        public Topic? TargetTopicId { get; set; }

        public ICollection<Post> Replies { get; set; }


    }
}
