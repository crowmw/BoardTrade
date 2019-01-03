﻿using System.ComponentModel.DataAnnotations;

namespace BoardTrade.Dtos
{
    public class CredentialDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
