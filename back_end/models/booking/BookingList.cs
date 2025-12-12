namespace BackEnd.Models;

public class BookingList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int BookingId { get; set; }
    public string? BookingCode { get; set; }
    public int UserId { get; set; }
    public int HotelId { get; set; }
    public DateTime CheckinDate { get; set; }
    public DateTime CheckoutDate { get; set; }
    public string? BookingStatus { get; set; }
    public string? SpecialRequest { get; set; }
    public int InsuranceId { get; set; }
    public decimal InsurancePremiumAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? PaymentDeadline { get; set; }
    public bool CanRefund { get; set; }
    public int TotalNights { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public string? BookingSource { get; set; }
    public int GuestCount { get; set; }
    public string? HotelSnapshotJson { get; set; }
    public string? RoomSnapshotJson { get; set; }
    public string? InsuranceSnapshotJson { get; set; }
    public bool IsActive { get; set; }
}
