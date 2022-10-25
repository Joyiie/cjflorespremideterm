namespace joy.premidterm.Infrastructure.Domian.Models
{
    public class Payment
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Abbreviation { get; set; }
    }
}
