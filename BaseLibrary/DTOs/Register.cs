using System.ComponentModel.DataAnnotations;

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
        public string? CPF { get; set; }


        public DateTime? BirthDate { get; set; }


        public bool? Manager { get; set; }
    }
}
