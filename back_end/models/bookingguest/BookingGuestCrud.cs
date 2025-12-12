namespace BackEnd.Models;

public class BookingGuestCrud
{
    public int GuestId { get; set; }
    public required int BookingDetailId { get; set; }
    public required string GuestName { get; set; }
    public bool IsActive { get; set; }
}
