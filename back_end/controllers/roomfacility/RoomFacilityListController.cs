using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/roomfacility/roomfacilitylist")]
public class RoomFacilityListController : ControllerBase
{
    private readonly DataRoomFacilityList _data;

    public RoomFacilityListController(DataRoomFacilityList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<RoomFacilityList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{roomFacilityId:int}")]
    public async Task<ActionResult<IEnumerable<RoomFacilityList>>> ListById(int roomFacilityId)
    {
        long? id = roomFacilityId == 0 ? null : roomFacilityId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
