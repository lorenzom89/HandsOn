using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Airport : BaseEntity
    {
        [Required]
        public string CodIATA { get; set; } = string.Empty;

        public City? City { get; set; }

        [Required]
        public int CityId { get; set; }

    }
}
