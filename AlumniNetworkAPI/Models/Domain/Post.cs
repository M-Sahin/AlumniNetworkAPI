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

        
        public int? SenderUserId { get; set; }
        public User SenderUser { get; set; }

        public int? ReplyParentId { get; set; }
        public Post ReplyParent { get; set; }

        public int? TargetUserId { get; set; }
        public User TargetUser { get; set; }

        public int? TargetGroupId { get; set; }
        public Group TargetGroup { get; set; }

        public int? TargetTopicId { get; set; }
        public Topic TargetTopic { get; set; }

        public ICollection<Reply> Replies { get; set; }


    }
}
