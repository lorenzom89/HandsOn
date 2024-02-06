using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Flight : OtherBaseEntity
    {
        public Airport? OriginAirport { get; set; }
        [Required]
        public int OriginAirportId { get; set; }


        public Airport? DestinyAirport { get; set; }
        [Required]
        public int DestinyAirportId { get; set; }

        [Required]
        public DateTime FlightTime { get; set; }

        public List<FlightClass>? FlightClasses { get; set; }

        public List<Ticket>? Tickets { get; set; }
    }
}
