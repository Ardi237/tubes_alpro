// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/hotelphoto/hotelphotocrud")]
// public class HotelPhotoCrudController : ControllerBase
// {
//     private readonly DataHotelPhotoCrud _data;

//     public HotelPhotoCrudController(DataHotelPhotoCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] HotelPhotoCrud photo)
//     {
//         var result = await _data.CreateAsync(photo);
//         return Ok(result);
//     }

//     [HttpPost("update/{photoId:int}")]
//     public async Task<IActionResult> Update(int photoId, [FromBody] HotelPhotoCrud photo)
//     {
//         var result = await _data.UpdateAsync(photoId, photo);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{photoId:int}")]
//     public async Task<IActionResult> Delete(int photoId)
//     {
//         var result = await _data.DeleteAsync(photoId);
//         return Ok(result);
//     }
// }
