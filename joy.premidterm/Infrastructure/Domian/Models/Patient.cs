namespace joy.premidterm.Infrastructure.Domian.Models
{
    public class Patient
    {
        public Guid? Id { get; set; }
        public string? Code { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Enum.Type? Type { get; set; }
        public Guid? PaymentID { get; set; }    
       
    }
}
