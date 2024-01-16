﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
