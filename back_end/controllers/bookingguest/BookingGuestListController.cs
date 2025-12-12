using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/bookingguest/bookingguestlist")]
public class BookingGuestListController : ControllerBase
{
    private readonly DataBookingGuestList _data;

    public BookingGuestListController(DataBookingGuestList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<BookingGuestList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{guestId:int}")]
    public async Task<ActionResult<IEnumerable<BookingGuestList>>> ListById(int guestId)
    {
        long? id = guestId == 0 ? null : guestId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
