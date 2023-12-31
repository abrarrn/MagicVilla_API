﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Dto
{
    /*data transfer object (DTO) is an object that carries data between processes
     a wrapper to hide the model or database from being exposed in api*/
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string? Occupancy { get; set; }
        public string? Area { get; set; }
    }
}
