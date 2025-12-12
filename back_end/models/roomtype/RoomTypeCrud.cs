namespace BackEnd.Models;

public class RoomTypeCrud
{
    public int RoomTypeId { get; set; }
    public required string RoomTypeCode { get; set; }
    public required int HotelId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public int MaxGuest { get; set; }
    public required string BedType { get; set; }
    public required string RoomSize { get; set; }
    public int StockRoom { get; set; }
    public bool IsActive { get; set; }
}
