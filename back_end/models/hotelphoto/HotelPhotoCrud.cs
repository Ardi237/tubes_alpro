namespace BackEnd.Models;

public class HotelPhotoCrud
{
    public int PhotoId { get; set; }
    public required int HotelId { get; set; }
    public required string ImageUrl { get; set; }
    public bool IsCover { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}
