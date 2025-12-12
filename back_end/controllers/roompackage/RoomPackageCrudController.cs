// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/roompackage/roompackagecrud")]
// public class RoomPackageCrudController : ControllerBase
// {
//     private readonly DataRoomPackageCrud _data;

//     public RoomPackageCrudController(DataRoomPackageCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] RoomPackageCrud package)
//     {
//         var result = await _data.CreateAsync(package);
//         return Ok(result);
//     }

//     [HttpPost("update/{packageId:int}")]
//     public async Task<IActionResult> Update(int packageId, [FromBody] RoomPackageCrud package)
//     {
//         var result = await _data.UpdateAsync(packageId, package);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{packageId:int}")]
//     public async Task<IActionResult> Delete(int packageId)
//     {
//         var result = await _data.DeleteAsync(packageId);
//         return Ok(result);
//     }
// }
