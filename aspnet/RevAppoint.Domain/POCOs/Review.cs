namespace RevAppoint.Domain.POCOs
{
    public class Review
    {
      public Customer customer {get; set;}
      public Professional professional {get; set;}
      public long CustomerID {get; set;}
      public long ProfessionalID {get; set;}
      public string Grade {get; set;}    
    }
}