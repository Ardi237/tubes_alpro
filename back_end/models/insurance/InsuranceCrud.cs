namespace BackEnd.Models;

public class InsuranceCrud
{
    public int InsuranceId { get; set; }
    public required string InsuranceCode { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string PremiumType { get; set; }
    public decimal PremiumValue { get; set; }
    public required string ProviderName { get; set; }
    public bool IsActive { get; set; }
}
