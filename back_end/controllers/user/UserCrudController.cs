using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/user/usercrud")]
public class UserCrudController : ControllerBase
{
    private readonly DataUserCrud _data;

    public UserCrudController(DataUserCrud data)
    {
        _data = data;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] UserCrud user)
    {
        var result = await _data.CreateAsync(
            user.FullName,
            user.Email,
            user.PhoneNumber,
            user.PasswordHash);

        return Ok(result);
    }


   [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UserCrud user)
    {
        var result = await _data.UpdateAsync(
            user.UserId,
            user.FullName,
            user.Email,
            user.PhoneNumber,
            user.PasswordHash);

        return Ok(result);
    }



    [HttpDelete("delete/{userId:int}")]
    public async Task<IActionResult> Delete(int userId)
    {
        var result = await _data.DeleteAsync(userId);
        return Ok(result);
    }
}