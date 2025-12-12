namespace BackEnd.Models;

public class BookingDetailCrud
{
    public int BookingDetailId { get; set; }
    public required int BookingId { get; set; }
    public required int RoomTypeId { get; set; }
    public required int PackageId { get; set; }
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