using System;

namespace AlumniNetworkAPI.Models.DTO.Post
{
    public class PostUpdateDTO
    {
        public string Post_Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
