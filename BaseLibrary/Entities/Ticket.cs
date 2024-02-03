using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Ticket 
    {
        public int Id { get; set; }
        public required Flight Flight { get; set; }
        public required Class Class { get; set; }
        public required Person Passenger { get; set; }
        public required double TotalPrice { get; set; }
        public required DateTime PurchaseTime { get; set; }
        public required string Status { get; set; }
        public bool BaggageCheck { get; set; }

    }
}
