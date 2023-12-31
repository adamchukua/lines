﻿using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class UserBasicInfoDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        public string? Avatar { get; set; }
    }
}
