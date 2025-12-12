using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/bookingpackagehistory/bookingpackagehistorylist")]
public class BookingPackageHistoryListController : ControllerBase
{
    private readonly DataBookingPackageHistoryList _data;

    public BookingPackageHistoryListController(DataBookingPackageHistoryList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<BookingPackageHistoryList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{historyId:int}")]
    public async Task<ActionResult<IEnumerable<BookingPackageHistoryList>>> ListById(int historyId)
    {
        long? id = historyId == 0 ? null : historyId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
