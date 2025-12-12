using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/policy/policylist")]
public class PolicyListController : ControllerBase
{
    private readonly DataPolicyList _data;

    public PolicyListController(DataPolicyList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<PolicyList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{policyId:int}")]
    public async Task<ActionResult<IEnumerable<PolicyList>>> ListById(int policyId)
    {
        long? id = policyId == 0 ? null : policyId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
