using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTO.Event
{
    public class EventUpdateDTO
    {
        public int Event_Id { get; set; }

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

        //Hieronder moet start en eiddatum komen
    }
}
