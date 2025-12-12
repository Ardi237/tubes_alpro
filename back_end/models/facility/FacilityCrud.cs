namespace BackEnd.Models;

public class FacilityCrud
{
    public int FacilityId { get; set; }
    public required string FacilityCode { get; set; }
    public required string Name { get; set; }
    public string? IconUrl { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
