namespace BackEnd.Models;

public class BookingPackageHistoryCrud
{
    public int HistoryId { get; set; }
    public required int BookingId { get; set; }
    public required int OldPackageId { get; set; }
    public required int NewPackageId { get; set; }
    public decimal DifferenceAmount { get; set; }
    public required string ActionType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int ActionByAdminId { get; set; }
    public int ActionByUserId { get; set; }
    public string? Remarks { get; set; }
    public string? OldPackageSnapshotJson { get; set; }
    public string? NewPackageSnapshotJson { get; set; }
    public decimal OldTotalAmount { get; set; }
    public decimal NewTotalAmount { get; set; }
    public bool IsActive { get; set; }
}
