namespace BaseLibrary.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public required City City { get; set; }
        public required string Name { get; set; }
        public required string CodIATA { get; set; }
    }
}