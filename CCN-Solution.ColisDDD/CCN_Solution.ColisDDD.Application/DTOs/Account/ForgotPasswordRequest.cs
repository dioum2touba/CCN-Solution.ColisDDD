﻿using System.ComponentModel.DataAnnotations;

namespace CCNSolution.ColisDDD.Application.DTOs.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
