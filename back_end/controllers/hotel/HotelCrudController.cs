// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/hotel/hotelcrud")]
// public class HotelCrudController : ControllerBase
// {
//     private readonly DataHotelCrud _data;

//     public HotelCrudController(DataHotelCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] HotelCrud hotel)
//     {
//         var result = await _data.CreateAsync(hotel);
//         return Ok(result);
//     }

//     [HttpPost("update/{hotelId:int}")]
//     public async Task<IActionResult> Update(int hotelId, [FromBody] HotelCrud hotel)
//     {
//         var result = await _data.UpdateAsync(hotelId, hotel);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{hotelId:int}")]
//     public async Task<IActionResult> Delete(int hotelId)
//     {
//         var result = await _data.DeleteAsync(hotelId);
//         return Ok(result);
//     }
// }
