namespace AlumniNetworkAPI.Models.DTO.Post
{
    public class PostCreateDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int? SenderUserId { get; set; }

    }
}
