namespace BackEnd.Models;

public class RoomPackageList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int PackageId { get; set; }
    public string? PackageCode { get; set; }
    public int RoomTypeId { get; set; }
    public string? PackageName { get; set; }
    public string? BenefitText { get; set; }
    public decimal Price { get; set; }
    public bool IsRefundable { get; set; }
    public bool IncludeBreakfast { get; set; }
    public bool IncludeGym { get; set; }
    public bool IncludeParking { get; set; }
    public string? OtherBenefitJson { get; set; }
    public bool IsActive { get; set; }
}
