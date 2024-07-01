﻿using System.ComponentModel.DataAnnotations;

namespace Gourmand.DTO
{
    public class RestaurantDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Number { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
