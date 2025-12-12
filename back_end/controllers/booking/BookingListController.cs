using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/booking/bookinglist")]
public class BookingListController : ControllerBase
{
    private readonly DataBookingList _data;

    public BookingListController(DataBookingList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<BookingList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{bookingId:int}")]
    public async Task<ActionResult<IEnumerable<BookingList>>> ListById(int bookingId)
    {
        long? id = bookingId == 0 ? null : bookingId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
