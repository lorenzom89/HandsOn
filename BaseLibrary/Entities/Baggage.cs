using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Baggage : OtherBaseEntity
    {

        public Ticket? Tickets { get; set; }

        [Required] 
        public int TicketId { get; set; }
    }
}
