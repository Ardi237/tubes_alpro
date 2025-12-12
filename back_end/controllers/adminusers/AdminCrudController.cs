// using BackEnd.AccessData;
// using BackEnd.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace BackEnd.Controllers;

// [ApiController]
// [Route("api/admin/admincrud")]
// public class AdminCrudController : ControllerBase
// {
//     private readonly DataAdminCrud _data;

//     public AdminCrudController(DataAdminCrud data)
//     {
//         _data = data;
//     }

//     [HttpPost("create")]
//     public async Task<IActionResult> Create([FromBody] AdminCrud admin)
//     {
//         var result = await _data.CreateAsync(admin);
//         return Ok(result);
//     }

//     [HttpPost("update/{adminId:int}")]
//     public async Task<IActionResult> Update(int adminId, [FromBody] AdminCrud admin)
//     {
//         var result = await _data.UpdateAsync(adminId, admin);
//         return Ok(result);
//     }

//     [HttpDelete("delete/{adminId:int}")]
//     public async Task<IActionResult> Delete(int adminId)
//     {
//         var result = await _data.DeleteAsync(adminId);
//         return Ok(result);
//     }
// }
