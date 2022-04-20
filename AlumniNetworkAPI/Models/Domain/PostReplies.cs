using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.Domain
{
    public class PostReplies
    {
        [Key]
        public int PostReply_Id { get; set; }
        public int Postpost_id { get; set; }
        public Post post { get; set; }

        public int Replyreply_Id { get; set; }
        public Replies reply { get; set; }

    }
}
