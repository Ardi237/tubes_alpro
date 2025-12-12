using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/roomtype/roomtypelist")]
public class RoomTypeListController : ControllerBase
{
    private readonly DataRoomTypeList _data;

    public RoomTypeListController(DataRoomTypeList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<RoomTypeList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{roomTypeId:int}")]
    public async Task<ActionResult<IEnumerable<RoomTypeList>>> ListById(int roomTypeId)
    {
        long? id = roomTypeId == 0 ? null : roomTypeId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
