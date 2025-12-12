namespace BackEnd.Models;

public class PolicyList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int PolicyId { get; set; }
    public int HotelId { get; set; }
    public string? PolicyType { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}
