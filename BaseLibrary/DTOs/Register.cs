using System.ComponentModel.DataAnnotations;
using BaseLibrary.Helpers;

namespace BaseLibrary.DTOs
{
    public class Register : AccountBase
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]

        public string? Fullname { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Required]

        public string? ConfirmPassword { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        [ValidChars(validChars:"0123456789", ErrorMessage ="Only numbers are allowed")]
        [ValidCPF]
        public string? CPF { get; set; }


        public DateTime? BirthDate { get; set; }

    }
}
