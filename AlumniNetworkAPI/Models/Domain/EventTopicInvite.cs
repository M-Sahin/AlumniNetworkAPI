using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniNetworkAPI.Models.Domain
{
    public class EventTopicInvite
    {
        [Key]
        public int EventTopicId { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public Group Topic { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
