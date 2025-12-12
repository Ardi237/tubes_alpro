// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/roomfacility/roomfacilitycrud")]
// public class RoomFacilityCrudController : ControllerBase
// {
//     private readonly DataRoomFacilityCrud _data;

//     public RoomFacilityCrudController(DataRoomFacilityCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] RoomFacilityCrud roomFacility)
//     {
//         var result = await _data.CreateAsync(roomFacility);
//         return Ok(result);
//     }

//     [HttpPost("update/{roomFacilityId:int}")]
//     public async Task<IActionResult> Update(int roomFacilityId, [FromBody] RoomFacilityCrud roomFacility)
//     {
//         var result = await _data.UpdateAsync(roomFacilityId, roomFacility);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{roomFacilityId:int}")]
//     public async Task<IActionResult> Delete(int roomFacilityId)
//     {
//         var result = await _data.DeleteAsync(roomFacilityId);
//         return Ok(result);
//     }
// }
