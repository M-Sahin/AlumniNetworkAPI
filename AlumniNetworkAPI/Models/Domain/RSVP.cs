using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniNetworkAPI.Models.Domain
{
    public class RSVP
    {
        [Key]
        public int RSVP_Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int Guest_Count { get; set; }
        public DateTime Last_Updated { get; set; }

    }
}
