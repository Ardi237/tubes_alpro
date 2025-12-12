// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/roomtype/roomtypecrud")]
// public class RoomTypeCrudController : ControllerBase
// {
//     private readonly DataRoomTypeCrud _data;

//     public RoomTypeCrudController(DataRoomTypeCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] RoomTypeCrud roomType)
//     {
//         var result = await _data.CreateAsync(roomType);
//         return Ok(result);
//     }

//     [HttpPost("update/{roomTypeId:int}")]
//     public async Task<IActionResult> Update(int roomTypeId, [FromBody] RoomTypeCrud roomType)
//     {
//         var result = await _data.UpdateAsync(roomTypeId, roomType);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{roomTypeId:int}")]
//     public async Task<IActionResult> Delete(int roomTypeId)
//     {
//         var result = await _data.DeleteAsync(roomTypeId);
//         return Ok(result);
//     }
// }
