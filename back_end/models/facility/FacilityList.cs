namespace BackEnd.Models;

public class FacilityList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int FacilityId { get; set; }
    public string? FacilityCode { get; set; }
    public string? Name { get; set; }
    public string? IconUrl { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
