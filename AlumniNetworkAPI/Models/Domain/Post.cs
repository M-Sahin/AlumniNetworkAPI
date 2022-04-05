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
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
        public int? SenderId { get; set; }

        public int? ReplyParentId { get; set; }

        public int? TargetUserId { get; set; }
        public int? TargetGroupId { get; set; }
        public int? TargetTopicId { get; set; }


    }
}
