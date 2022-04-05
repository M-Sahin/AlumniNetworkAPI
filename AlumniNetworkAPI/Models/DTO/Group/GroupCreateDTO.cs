﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniNetworkAPI.Models.DTO.Group
{
    public class GroupCreateDTO
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Name cant be more than 50 characters.")]
        public string name { get; set; }
        [Required]
        [MaxLength(500)]
        public string description { get; set; }

        [Required]
        public bool isPrivate { get; set; }
    }
}
