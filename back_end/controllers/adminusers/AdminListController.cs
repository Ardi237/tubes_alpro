using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/admin/adminlist")]
public class AdminListController : ControllerBase
{
    private readonly DataAdminList _data;

    public AdminListController(DataAdminList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<AdminList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{adminId:int}")]
    public async Task<ActionResult<IEnumerable<AdminList>>> ListById(int adminId)
    {
        long? id = adminId == 0 ? null : adminId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
