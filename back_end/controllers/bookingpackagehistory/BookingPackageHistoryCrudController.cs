// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/bookingpackagehistory/bookingpackagehistorycrud")]
// public class BookingPackageHistoryCrudController : ControllerBase
// {
//     private readonly DataBookingPackageHistoryCrud _data;

//     public BookingPackageHistoryCrudController(DataBookingPackageHistoryCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] BookingPackageHistoryCrud history)
//     {
//         var result = await _data.CreateAsync(history);
//         return Ok(result);
//     }

//     [HttpPost("update/{historyId:int}")]
//     public async Task<IActionResult> Update(int historyId, [FromBody] BookingPackageHistoryCrud history)
//     {
//         var result = await _data.UpdateAsync(historyId, history);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{historyId:int}")]
//     public async Task<IActionResult> Delete(int historyId)
//     {
//         var result = await _data.DeleteAsync(historyId);
//         return Ok(result);
//     }
// }
