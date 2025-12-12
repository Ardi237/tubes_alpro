// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/bookingdetail/bookingdetailcrud")]
// public class BookingDetailCrudController : ControllerBase
// {
//     private readonly DataBookingDetailCrud _data;

//     public BookingDetailCrudController(DataBookingDetailCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] BookingDetailCrud detail)
//     {
//         var result = await _data.CreateAsync(detail);
//         return Ok(result);
//     }

//     [HttpPost("update/{bookingDetailId:int}")]
//     public async Task<IActionResult> Update(int bookingDetailId, [FromBody] BookingDetailCrud detail)
//     {
//         var result = await _data.UpdateAsync(bookingDetailId, detail);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{bookingDetailId:int}")]
//     public async Task<IActionResult> Delete(int bookingDetailId)
//     {
//         var result = await _data.DeleteAsync(bookingDetailId);
//         return Ok(result);
//     }
// }
