namespace MindWell_PersonalLogService.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}