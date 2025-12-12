namespace BackEnd.Models;

public class RoomTypeList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int RoomTypeId { get; set; }
    public string? RoomTypeCode { get; set; }
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public int MaxGuest { get; set; }
    public string? BedType { get; set; }
    public string? RoomSize { get; set; }
    public int StockRoom { get; set; }
    public bool IsActive { get; set; }
}
