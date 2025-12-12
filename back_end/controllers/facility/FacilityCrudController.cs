// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/facility/facilitycrud")]
// public class FacilityCrudController : ControllerBase
// {
//     private readonly DataFacilityCrud _data;

//     public FacilityCrudController(DataFacilityCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] FacilityCrud facility)
//     {
//         var result = await _data.CreateAsync(facility);
//         return Ok(result);
//     }

//     [HttpPost("update/{facilityId:int}")]
//     public async Task<IActionResult> Update(int facilityId, [FromBody] FacilityCrud facility)
//     {
//         var result = await _data.UpdateAsync(facilityId, facility);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{facilityId:int}")]
//     public async Task<IActionResult> Delete(int facilityId)
//     {
//         var result = await _data.DeleteAsync(facilityId);
//         return Ok(result);
//     }
// }
