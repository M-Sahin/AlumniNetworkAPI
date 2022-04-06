using System;
using System.Collections.Generic;


namespace AlumniNetworkAPI.Models.DTO.Post
{
    public class PostReadDTO
    {

        public int Post_Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
        public int SenderUserId { get; set; }
        public List<int> Replies { get; set; }


    }
}
