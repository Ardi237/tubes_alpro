// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/bookingguest/bookingguestcrud")]
// public class BookingGuestCrudController : ControllerBase
// {
//     private readonly DataBookingGuestCrud _data;

//     public BookingGuestCrudController(DataBookingGuestCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] BookingGuestCrud guest)
//     {
//         var result = await _data.CreateAsync(guest);
//         return Ok(result);
//     }

//     [HttpPost("update/{guestId:int}")]
//     public async Task<IActionResult> Update(int guestId, [FromBody] BookingGuestCrud guest)
//     {
//         var result = await _data.UpdateAsync(guestId, guest);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{guestId:int}")]
//     public async Task<IActionResult> Delete(int guestId)
//     {
//         var result = await _data.DeleteAsync(guestId);
//         return Ok(result);
//     }
// }
