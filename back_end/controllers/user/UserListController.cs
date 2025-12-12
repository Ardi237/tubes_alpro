using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/user/userlist")]
public class UserListController : ControllerBase
{
    private readonly DataUserList _data;

    public UserListController(DataUserList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<IActionResult> GetList(
        [FromQuery] string searchText = "")
    {
        var result = await _data.FindAsync(searchText);
        return Ok(result);
    }


   [HttpGet("byid/{userId:int}")]
    public async Task<IActionResult> Read(int userId)
    {
        var list = await _data.ListAsync(userId);

        // Karena list = UserList[]
        if (list == null || list.Length == 0)
            return NotFound(new { success = 0, message = "Data tidak ditemukan" });

        var item = list[0];

        if (!item.Success)
            return BadRequest(new { success = 0, message = item.Message });

        return Ok(item);
    }


}
