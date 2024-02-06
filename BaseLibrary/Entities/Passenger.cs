using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using BaseLibrary.Helpers;

namespace BaseLibrary.Entities
{
    public class Passenger : BaseEntity
    {
        [Required, ValidCPF, ValidChars(validChars:"-.0123456789"), MinLength(11), MaxLength(14)]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;


        public List<Ticket>? Tickets { get; set; }
    }
}
