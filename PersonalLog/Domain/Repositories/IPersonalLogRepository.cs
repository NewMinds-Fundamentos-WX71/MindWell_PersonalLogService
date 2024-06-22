namespace MindWell_PersonalLogService.PersonalLog.Domain.Repositories;

public interface IPersonalLogRepository
{
    Task<IEnumerable<Models.PersonalLog>> ListAsync();
    Task<Models.PersonalLog> FindByIdAsync(int id);
    Task<IEnumerable<Models.PersonalLog>> GetByUserIdAsync(int id);
    Task AddAsync(Models.PersonalLog personalLog);
    void Update(Models.PersonalLog personalLog);
    void Remove(Models.PersonalLog personalLog);
}