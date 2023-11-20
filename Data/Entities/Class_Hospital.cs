namespace api.Entities;

public class Class_Hospital
{
    [Key]
    public int HospitalId { get; set; }
    public String? SelectedHospitalName { get; set; }
    public String? HospitalName { get; set; }
    public String? HospitalNo { get; set; }
    public String? Description { get; set; }
    public String? Address { get; set; }
    public String? Telephone { get; set; }
    public String? Fax { get; set; }
    public String? City { get; set; }
    public string? Country { get; set; }
    public String? SampleMrn { get; set; }
    public String? RegExpr { get; set; }
    public bool UsesOnlineValveInventory { get; set; }
    public String? ImageUrl { get; set; }
    public String? OpReportDetails1 { get; set; }
    public String? OpReportDetails2 { get; set; }
    public String? OpReportDetails3 { get; set; }
    public String? OpReportDetails4 { get; set; }
    public String? OpReportDetails5 { get; set; }
    public String? OpReportDetails6 { get; set; }
    public String? OpReportDetails7 { get; set; }
    public String? OpReportDetails8 { get; set; }
    public String? OpReportDetails9 { get; set; }

}
