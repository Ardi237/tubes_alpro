using BackEnd.AccessData;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/facility/facilitylist")]
public class FacilityListController : ControllerBase
{
    private readonly DataFacilityList _data;

    public FacilityListController(DataFacilityList data)
    {
        _data = data;
    }

    [HttpGet("find")]
    public async Task<ActionResult<IEnumerable<FacilityList>>> Find([FromQuery] string? search_text)
    {
        var text = search_text ?? "";
        var results = await _data.FindAsync(text);
        return Ok(results);
    }

    [HttpGet("byid/{facilityId:int}")]
    public async Task<ActionResult<IEnumerable<FacilityList>>> ListById(int facilityId)
    {
        long? id = facilityId == 0 ? null : facilityId;
        var results = await _data.ListAsync(id);
        return Ok(results);
    }
}
