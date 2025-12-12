// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/policy/policycrud")]
// public class PolicyCrudController : ControllerBase
// {
//     private readonly DataPolicyCrud _data;

//     public PolicyCrudController(DataPolicyCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] PolicyCrud policy)
//     {
//         var result = await _data.CreateAsync(policy);
//         return Ok(result);
//     }

//     [HttpPost("update/{policyId:int}")]
//     public async Task<IActionResult> Update(int policyId, [FromBody] PolicyCrud policy)
//     {
//         var result = await _data.UpdateAsync(policyId, policy);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{policyId:int}")]
//     public async Task<IActionResult> Delete(int policyId)
//     {
//         var result = await _data.DeleteAsync(policyId);
//         return Ok(result);
//     }
// }
