namespace BaseLibrary.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int NumOfSeats{ get; set; }
        public required double PricePerSeat { get; set; }
        public List<Ticket> Tickets { get; set; } = [];
    }
}
