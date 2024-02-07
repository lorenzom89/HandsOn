using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class FlightClass : BaseEntity
    {
        [Required]
        public int SeatQuantity { get; set; }

        public int RemainingSeats => ((Tickets is not null) && (Tickets!.Count != 0)) ? (SeatQuantity - Tickets.Count) : SeatQuantity;

        [Required, DataType(DataType.Currency)]
        public double SeatPrice { get; set; }

        [JsonIgnore]
        public List<Ticket>? Tickets { get; set; }

        
        public Flight? Flight { get; set; }
        [Required]
        public int FlightId { get; set; }


    }
}
