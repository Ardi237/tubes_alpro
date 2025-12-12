namespace BackEnd.Models;

public class HotelPhotoList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int PhotoId { get; set; }
    public int HotelId { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsCover { get; set; }
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}
