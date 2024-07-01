using System.ComponentModel.DataAnnotations;

namespace Gourmand.DTO
{
    public class EmailResetPasswordDTO
    {
        [Required]
        public string? email { get; set; }
    }
}
