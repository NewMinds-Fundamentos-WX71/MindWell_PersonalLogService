using AutoMapper;
using MindWell_PersonalLogService.PersonalLog.Resources.POST;

namespace MindWell_PersonalLogService.PersonalLog.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePersonalLogResource, Domain.Models.PersonalLog>();
    }
}