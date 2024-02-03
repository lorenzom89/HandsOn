using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public required int FlightNumber { get; set; }
        public required Airport Origin { get; set; }
        public required Airport Destiny { get; set; }
        public required DateTime FlightTime { get; set; }
        public List<Class> Classes { get; set; } = [];
        public List<Ticket> Passengers { get; set; } = [];
    }

}
