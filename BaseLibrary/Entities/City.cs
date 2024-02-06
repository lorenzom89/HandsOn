using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        [Required]
        public string UF { get; set; } = string.Empty;

        public List<Airport>? Airports { get; set; } 
    }
}
