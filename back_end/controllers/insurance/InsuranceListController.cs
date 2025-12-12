using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/insurance/insurancelist")]
public class InsuranceListController : ControllerBase
{
    private readonly DataInsuranceList _data;

    public InsuranceListController(DataInsuranceList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<InsuranceList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{insuranceId:int}")]
    public async Task<ActionResult<IEnumerable<InsuranceList>>> ListById(int insuranceId)
    {
        long? id = insuranceId == 0 ? null : insuranceId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
