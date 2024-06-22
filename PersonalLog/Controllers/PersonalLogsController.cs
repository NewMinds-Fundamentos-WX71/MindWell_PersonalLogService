using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_PersonalLogService.PersonalLog.Domain.Communication;
using MindWell_PersonalLogService.PersonalLog.Domain.Services;
using MindWell_PersonalLogService.PersonalLog.Resources.GET;
using MindWell_PersonalLogService.PersonalLog.Resources.POST;
using MindWell_PersonalLogService.Shared.Extensions;

namespace MindWell_PersonalLogService.PersonalLog.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PersonalLogsController : ControllerBase
{
    private readonly IPersonalLogService _personalLogService;
    private readonly IMapper _mapper;

    public PersonalLogsController(IPersonalLogService personalLogService, IMapper mapper)
    {
        _personalLogService = personalLogService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PersonalLogResource>> GetAllAsync()
    {
        var personalLogs = await _personalLogService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.PersonalLog>, IEnumerable<PersonalLogResource>>(personalLogs);
        
        return resources;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _personalLogService.GetByIdAsync(id);

        if (result == null)
        {
            return NotFound(new PersonalLogResponse("PersonalLog not found").Message);
        }

        var resource = _mapper.Map<Domain.Models.PersonalLog, PersonalLogResource>(result);

        return Ok(resource);
    }
    
    [HttpGet("user/{id:int}")]
    public async Task<IActionResult> GetByUserIdAsync(int id)
    {
        var result = await _personalLogService.GetByUserIdAsync(id);

        if (!result.Any())
        {
            return NotFound(new PersonalLogResponse("PersonalLogs not found").Message);
        }

        var resources = _mapper.Map<IEnumerable<Domain.Models.PersonalLog>, IEnumerable<PersonalLogResource>>(result);

        return Ok(resources);
    }

    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePersonalLogResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var personalLoging = _mapper.Map<SavePersonalLogResource, Domain.Models.PersonalLog>(resource);
        var result = await _personalLogService.SaveAsync(personalLoging);

        if (!result.Success)
            return BadRequest(result.Message);

        var personalLogingResource = _mapper.Map<Domain.Models.PersonalLog, PersonalLogResource>(result.Resource);

        return Ok(personalLogingResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePersonalLogResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var personalLoging = _mapper.Map<SavePersonalLogResource, Domain.Models.PersonalLog>(resource);
        var result = await _personalLogService.UpdateAsync(id, personalLoging);

        if (!result.Success)
            return BadRequest(result.Message);

        var personalLogingResource = _mapper.Map<Domain.Models.PersonalLog, PersonalLogResource>(result.Resource);

        return Ok(personalLogingResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _personalLogService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var personalLogingResource = _mapper.Map<Domain.Models.PersonalLog, PersonalLogResource>(result.Resource);

        return Ok(personalLogingResource);
    }
}