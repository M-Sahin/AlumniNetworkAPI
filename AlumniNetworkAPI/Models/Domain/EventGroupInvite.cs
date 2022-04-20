using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniNetworkAPI.Models.Domain
{
    public class EventGroupInvite
    {
        [Key]
        public int inviteId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
