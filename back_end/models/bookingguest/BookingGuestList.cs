namespace BackEnd.Models;

public class BookingGuestList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int GuestId { get; set; }
    public int BookingDetailId { get; set; }
    public string? GuestName { get; set; }
    public bool IsActive { get; set; }
}
