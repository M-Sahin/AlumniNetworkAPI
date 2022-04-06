using System;

namespace AlumniNetworkAPI.Models.DTO.Post
{
    public class PostReadDTO
    {

        public int Post_Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
