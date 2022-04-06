using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniNetworkAPI.Models.DTO.User
{
    public class UserUpdateDTO
    {
        [Key]
        public int userId { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        [Url]
        [MaxLength(500)]
        public string picture { get; set; }
        [MaxLength(50)]
        public string gender { get; set; }
        [MaxLength(50)]
        public string status { get; set; }
        [MaxLength(50)]
        public string bio { get; set; }
        [MaxLength(50)]
        public string fun_fact { get; set; }
    }
}
