namespace BackEnd.Models;

public class BookingPaymentCrud
{
    public int PaymentId { get; set; }
    public required int BookingId { get; set; }
    public required string PaymentMethod { get; set; }
    public required string PaymentChannel { get; set; }
    public decimal AmountRoom { get; set; }
    public decimal AmountTax { get; set; }
    public decimal AmountServiceFee { get; set; }
    public decimal AmountInsurance { get; set; }
    public decimal TotalAmount { get; set; }
    public required string PaymentStatus { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? PaymentCode { get; set; }
    public bool IsAdjustment { get; set; }
    public string? AdjustmentType { get; set; }
    public decimal AmountDiscount { get; set; }
    public decimal AmountAdminFee { get; set; }
    public required string Currency { get; set; }
    public string? GatewayReferenceNo { get; set; }
    public string? GatewayResponseJson { get; set; }
    public bool IsActive { get; set; }
}
