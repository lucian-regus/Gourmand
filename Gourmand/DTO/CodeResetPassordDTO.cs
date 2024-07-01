using System.ComponentModel.DataAnnotations;

namespace Gourmand.DTO
{
    public class CodeResetPassordDTO
    {
        [Required]
        public int code {  get; set; }
        [Required]
        public string? password { get; set; }
    }
}
