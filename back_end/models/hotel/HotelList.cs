namespace BackEnd.Models;

public class HotelList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int HotelId { get; set; }
    public string? HotelCode { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Description { get; set; }
    public decimal RatingAvg { get; set; }
    public string? CheckinTime { get; set; }
    public string? CheckoutTime { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
