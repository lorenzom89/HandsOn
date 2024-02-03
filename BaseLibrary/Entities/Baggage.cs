namespace BaseLibrary.Entities
{
    public class Baggage 
    {
        public int Id { get; set; }
        public required Ticket Ticket { get; set; }
    }
}
