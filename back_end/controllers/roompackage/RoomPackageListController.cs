using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/roompackage/roompackagelist")]
public class RoomPackageListController : ControllerBase
{
    private readonly DataRoomPackageList _data;

    public RoomPackageListController(DataRoomPackageList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<RoomPackageList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{packageId:int}")]
    public async Task<ActionResult<IEnumerable<RoomPackageList>>> ListById(int packageId)
    {
        long? id = packageId == 0 ? null : packageId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
