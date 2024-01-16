﻿using Shop.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Accounts
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "gmail.com", ErrorMessage = "Email domain must be gmail.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
