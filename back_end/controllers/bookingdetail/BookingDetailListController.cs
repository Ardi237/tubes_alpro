using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/bookingdetail/bookingdetaillist")]
public class BookingDetailListController : ControllerBase
{
    private readonly DataBookingDetailList _data;

    public BookingDetailListController(DataBookingDetailList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<BookingDetailList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{bookingDetailId:int}")]
    public async Task<ActionResult<IEnumerable<BookingDetailList>>> ListById(int bookingDetailId)
    {
        long? id = bookingDetailId == 0 ? null : bookingDetailId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
