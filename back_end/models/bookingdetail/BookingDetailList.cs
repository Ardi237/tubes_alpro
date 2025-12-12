    namespace BackEnd.Models;

public class BookingDetailList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int BookingDetailId { get; set; }
    public int BookingId { get; set; }
    public int RoomTypeId { get; set; }
    public int PackageId { get; set; }
    public int QtyRoom { get; set; }
    public decimal PricePerNight { get; set; }
    public int Nights { get; set; }
    public decimal Subtotal { get; set; }
    public decimal PriceRoomBase { get; set; }
    public decimal PricePackageAddon { get; set; }
    public string? RoomtypeSnapshotJson { get; set; }
    public string? PackageSnapshotJson { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal ServiceFeeAmount { get; set; }
    public bool IsActive { get; set; }
}
