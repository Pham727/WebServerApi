﻿using System.ComponentModel.DataAnnotations;

namespace WebServerAPI.Models
{
    public class SignUpModel
    {
        [Required]
        public string FristName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
