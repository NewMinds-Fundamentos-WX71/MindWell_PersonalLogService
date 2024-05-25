using MindWell_PersonalLogService.Shared.Domain.Services.Communication;

namespace MindWell_PersonalLogService.PersonalLog.Domain.Communication;

public class PersonalLogResponse : BaseResponse<Models.PersonalLog>
{
    public PersonalLogResponse(string message) : base(message)
    {
    }

    public PersonalLogResponse(Models.PersonalLog resource) : base(resource)
    {
    }
}