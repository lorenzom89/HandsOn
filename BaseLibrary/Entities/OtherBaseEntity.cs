using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class OtherBaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string SearchCode { get; set; } = string.Empty;
    }
}
