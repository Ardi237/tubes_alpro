namespace BackEnd.Models;

public class HotelCrud
{
    public int HotelId { get; set; }
    public required string HotelCode { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public string? Description { get; set; }
    public decimal RatingAvg { get; set; }
    public required string CheckinTime { get; set; }
    public required string CheckoutTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
}
