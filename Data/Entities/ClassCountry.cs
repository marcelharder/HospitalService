namespace api.Entities;
public class ClassCountry
{
    [Key]
    public int Id { get; set; }
    public int TelCode { get; set; }
    public string? IsoCode {get;set;}
    public string? Description { get; set; }
}