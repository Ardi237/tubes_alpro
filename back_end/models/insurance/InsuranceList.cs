namespace BackEnd.Models;

public class InsuranceList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int InsuranceId { get; set; }
    public string? InsuranceCode { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PremiumType { get; set; }
    public decimal PremiumValue { get; set; }
    public string? ProviderName { get; set; }
    public bool IsActive { get; set; }
}
