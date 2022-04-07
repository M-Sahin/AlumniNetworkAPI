using System;
using System.ComponentModel.DataAnnotations;
using AlumniNetworkAPI.Models.Domain;

namespace AlumniNetworkAPI.Models.Domain
{
    public class Event
    {

        [Key]

        public int Event_Id { get; set; }

        [Required]
        public int? CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Name cant be longer than 12 characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Description cant be longer than 128 characters.")]
        public string Description { get; set; }
        
        [Required]
        public bool AllowGuests { get; set; }

        [Url]
        [Required]
        public string Banner_Image { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }



    }
}
