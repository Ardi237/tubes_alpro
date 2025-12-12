namespace BackEnd.Models;

public class RoomPackageCrud
{
    public int PackageId { get; set; }
    public required string PackageCode { get; set; }
    public required int RoomTypeId { get; set; }
    public required string PackageName { get; set; }
    public string? BenefitText { get; set; }
    public decimal Price { get; set; }
    public bool IsRefundable { get; set; }
    public bool IncludeBreakfast { get; set; }
    public bool IncludeGym { get; set; }
    public bool IncludeParking { get; set; }
    public string? OtherBenefitJson { get; set; }
    public bool IsActive { get; set; }
}
