using Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class RepostBasicInfoDTO
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long PostId { get; set; }
        [Required]
        public UserBasicInfoDTO User { get; set; }
        [Required]
        public PostBasicInfoDTO Post { get; set; }
    }
}
