namespace BackEnd.Models;

public class BookingPaymentList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int PaymentId { get; set; }
    public int BookingId { get; set; }
    public string? PaymentMethod { get; set; }
    public string? PaymentChannel { get; set; }
    public decimal AmountRoom { get; set; }
    public decimal AmountTax { get; set; }
    public decimal AmountServiceFee { get; set; }
    public decimal AmountInsurance { get; set; }
    public decimal TotalAmount { get; set; }
    public string? PaymentStatus { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? PaymentCode { get; set; }
    public bool IsAdjustment { get; set; }
    public string? AdjustmentType { get; set; }
    public decimal AmountDiscount { get; set; }
    public decimal AmountAdminFee { get; set; }
    public string? Currency { get; set; }
    public string? GatewayReferenceNo { get; set; }
    public string? GatewayResponseJson { get; set; }
    public bool IsActive { get; set; }
}
