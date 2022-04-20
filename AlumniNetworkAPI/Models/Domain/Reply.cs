using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.Domain
{
    public class Reply
    {
        [Key]
        public int Reply_Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Text cant be longer than 500 characters.")]
        public string Body { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
