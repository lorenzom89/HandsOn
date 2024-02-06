using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Ticket : OtherBaseEntity
    {
        [Required]
        public string Seat { get; set; } = string.Empty;

        [Required]
        public bool Baggage { get; set; } = false;


        [Required, DataType(DataType.Currency)]
        public double TotalPrice => Baggage ? (FlightClass!.SeatPrice * 1.1) : FlightClass!.SeatPrice;

        
        public Flight? Flight { get; set; }
        [Required]
        public int FlightId { get; set; }



        public FlightClass? FlightClass { get; set; }
        [Required]
        public int FlightClassId { get; set; }
        


        public Passenger? Passenger { get; set; }
        [Required]
        public int PassengerId { get; set; }

    }
}
