namespace BackEnd.Models;

public class RoomFacilityCrud
{
    public int RoomFacilityId { get; set; }
    public required int RoomTypeId { get; set; }
    public required int FacilityId { get; set; }
    public bool IsActive { get; set; }
}
