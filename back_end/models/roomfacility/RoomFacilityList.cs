namespace BackEnd.Models;

public class RoomFacilityList
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public int RoomFacilityId { get; set; }
    public int RoomTypeId { get; set; }
    public int FacilityId { get; set; }
    public bool IsActive { get; set; }
}
