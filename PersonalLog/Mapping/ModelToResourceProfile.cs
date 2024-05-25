using AutoMapper;
using MindWell_PersonalLogService.PersonalLog.Resources.GET;

namespace MindWell_PersonalLogService.PersonalLog.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.PersonalLog, PersonalLogResource>();
    }
}