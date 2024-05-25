using MindWell_PersonalLogService.PersonalLog.Domain.Communication;

namespace MindWell_PersonalLogService.PersonalLog.Domain.Services;

public interface IPersonalLogService
{
    Task<IEnumerable<Models.PersonalLog>> ListAsync();
    Task<Models.PersonalLog> GetByIdAsync(int id);
    Task<PersonalLogResponse> SaveAsync(Models.PersonalLog personalLog);
    Task<PersonalLogResponse> UpdateAsync(int id, Models.PersonalLog personalLog);
    Task<PersonalLogResponse> DeleteAsync(int id);
}