namespace BackEnd.Models;

public class BookingPackageHistoryList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int HistoryId { get; set; }
    public int BookingId { get; set; }
    public int OldPackageId { get; set; }
    public int NewPackageId { get; set; }
    public decimal DifferenceAmount { get; set; }
    public string? ActionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ActionByAdminId { get; set; }
    public int ActionByUserId { get; set; }
    public string? Remarks { get; set; }
    public string? OldPackageSnapshotJson { get; set; }
    public string? NewPackageSnapshotJson { get; set; }
    public decimal OldTotalAmount { get; set; }
    public decimal NewTotalAmount { get; set; }
    public bool IsActive { get; set; }
}
