using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        [Required]
        public string UF { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Airport>? Airports { get; set; } 
    }
}
