// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/insurance/insurancecrud")]
// public class InsuranceCrudController : ControllerBase
// {
//     private readonly DataInsuranceCrud _data;

//     public InsuranceCrudController(DataInsuranceCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] InsuranceCrud insurance)
//     {
//         var result = await _data.CreateAsync(insurance);
//         return Ok(result);
//     }

//     [HttpPost("update/{insuranceId:int}")]
//     public async Task<IActionResult> Update(int insuranceId, [FromBody] InsuranceCrud insurance)
//     {
//         var result = await _data.UpdateAsync(insuranceId, insurance);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{insuranceId:int}")]
//     public async Task<IActionResult> Delete(int insuranceId)
//     {
//         var result = await _data.DeleteAsync(insuranceId);
//         return Ok(result);
//     }
// }
