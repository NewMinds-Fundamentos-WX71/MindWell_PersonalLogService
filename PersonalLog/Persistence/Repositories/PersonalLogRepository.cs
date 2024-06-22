using Microsoft.EntityFrameworkCore;
using MindWell_PersonalLogService.PersonalLog.Domain.Repositories;
using MindWell_PersonalLogService.Shared.Persistence.Contexts;
using MindWell_PersonalLogService.Shared.Persistence.Repositories;

namespace MindWell_PersonalLogService.PersonalLog.Persistence.Repositories;

public class PersonalLogRepository : BaseRepository, IPersonalLogRepository
{
    public PersonalLogRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.PersonalLog>> ListAsync()
    {
        return await _context.PersonalLogs.ToListAsync();
    }

    public async Task<Domain.Models.PersonalLog> FindByIdAsync(int id)
    {
        return await _context.PersonalLogs.FindAsync(id);
    }

    public async Task<IEnumerable<Domain.Models.PersonalLog>> GetByUserIdAsync(int id)
    {
        return await _context.PersonalLogs.Where(x => x.Users_Id == id).ToListAsync();
    }

    public async Task AddAsync(Domain.Models.PersonalLog personalLog)
    {
        await _context.PersonalLogs.AddAsync(personalLog);
    }

    public void Update(Domain.Models.PersonalLog personalLog)
    {
        _context.Update(personalLog);
    }

    public void Remove(Domain.Models.PersonalLog personalLog)
    {
        _context.PersonalLogs.Remove(personalLog);
    }
}