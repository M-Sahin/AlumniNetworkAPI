using System;
using System.ComponentModel.DataAnnotations;
using AlumniNetworkAPI.Models.Domain;

namespace AlumniNetworkAPI.Models.DTO.Event
{
    public class EventCreateDTO
    {
        public int CreatedByUserId { get; set; }
        public int Event_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AllowGuests { get; set; }
        public string Banner_Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //Hieronder moet start en eiddatum komen
    }
}
