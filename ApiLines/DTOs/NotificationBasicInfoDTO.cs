using Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class NotificationBasicInfoDTO
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required, MaxLength(100)]
        public string Text { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public UserBasicInfoDTO User { get; set; }
    }
}
