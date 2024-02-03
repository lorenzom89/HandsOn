namespace BaseLibrary.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public required string Fullname { get; set; }
        public required string CPF { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }
}
