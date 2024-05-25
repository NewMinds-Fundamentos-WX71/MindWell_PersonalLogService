using MindWell_PersonalLogService.Shared.Persistence.Contexts;

namespace MindWell_PersonalLogService.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}