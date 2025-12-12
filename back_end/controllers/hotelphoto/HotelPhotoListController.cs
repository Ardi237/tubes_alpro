using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/hotelphoto/hotelphotolist")]
public class HotelPhotoListController : ControllerBase
{
    private readonly DataHotelPhotoList _data;

    public HotelPhotoListController(DataHotelPhotoList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<HotelPhotoList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{photoId:int}")]
    public async Task<ActionResult<IEnumerable<HotelPhotoList>>> ListById(int photoId)
    {
        long? id = photoId == 0 ? null : photoId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
