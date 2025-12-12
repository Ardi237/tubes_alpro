using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/hotel/hotellist")]
public class HotelListController : ControllerBase
{
    private readonly DataHotelList _data;

    public HotelListController(DataHotelList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<HotelList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{hotelId:int}")]
    public async Task<ActionResult<IEnumerable<HotelList>>> ListById(int hotelId)
    {
        long? id = hotelId == 0 ? null : hotelId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
