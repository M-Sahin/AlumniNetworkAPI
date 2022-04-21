using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTO.Replies
{
    public class ReplyReadDTO
    {
        public int Reply_Id { get; set; }

        public string Body { get; set; }

        public DateTime TimeStamp { get; set; }

        public List<int> Posts { get; set; }

    }
}
