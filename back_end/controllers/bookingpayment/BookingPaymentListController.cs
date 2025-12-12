using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/bookingpayment/bookingpaymentlist")]
public class BookingPaymentListController : ControllerBase
{
    private readonly DataBookingPaymentList _data;

    public BookingPaymentListController(DataBookingPaymentList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<BookingPaymentList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{paymentId:int}")]
    public async Task<ActionResult<IEnumerable<BookingPaymentList>>> ListById(int paymentId)
    {
        long? id = paymentId == 0 ? null : paymentId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
