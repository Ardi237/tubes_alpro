// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/booking/bookingcrud")]
// public class BookingCrudController : ControllerBase
// {
//     private readonly DataBookingCrud _data;

//     public BookingCrudController(DataBookingCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] BookingCrud booking)
//     {
//         var result = await _data.CreateAsync(booking);
//         return Ok(result);
//     }

//     [HttpPost("update/{bookingId:int}")]
//     public async Task<IActionResult> Update(int bookingId, [FromBody] BookingCrud booking)
//     {
//         var result = await _data.UpdateAsync(bookingId, booking);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{bookingId:int}")]
//     public async Task<IActionResult> Delete(int bookingId)
//     {
//         var result = await _data.DeleteAsync(bookingId);
//         return Ok(result);
//     }
// }
