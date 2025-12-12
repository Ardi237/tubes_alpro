namespace BackEnd.Models;

public class PolicyCrud
{
    public int PolicyId { get; set; }
    public required int HotelId { get; set; }
    public required string PolicyType { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}
