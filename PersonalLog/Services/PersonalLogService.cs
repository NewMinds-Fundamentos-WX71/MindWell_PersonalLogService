using MindWell_PersonalLogService.PersonalLog.Domain.Communication;
using MindWell_PersonalLogService.PersonalLog.Domain.Repositories;
using MindWell_PersonalLogService.PersonalLog.Domain.Services;
using MindWell_PersonalLogService.Shared.Persistence.Repositories;

namespace MindWell_PersonalLogService.PersonalLog.Services;

public class PersonalLogService : IPersonalLogService
{
    private readonly IPersonalLogRepository _personalLogRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PersonalLogService(IPersonalLogRepository personalLogRepository, IUnitOfWork unitOfWork)
    {
        _personalLogRepository = personalLogRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.PersonalLog>> ListAsync()
    {
        return await _personalLogRepository.ListAsync();
    }

    public async Task<Domain.Models.PersonalLog> GetByIdAsync(int id)
    {
        return await _personalLogRepository.FindByIdAsync(id);
    }

    public async Task<IEnumerable<Domain.Models.PersonalLog>> GetByUserIdAsync(int id)
    {
        return await _personalLogRepository.GetByUserIdAsync(id);
    }

    public async Task<PersonalLogResponse> SaveAsync(Domain.Models.PersonalLog personalLog)
    {
        try
        {
            await _personalLogRepository.AddAsync(personalLog);
            await _unitOfWork.CompleteAsync();
            return new PersonalLogResponse(personalLog);
        }
        catch (Exception e)
        {
            return new PersonalLogResponse($"An error occurred while saving the personalLog: {e.Message}");
        }
    }

    public async Task<PersonalLogResponse> UpdateAsync(int id, Domain.Models.PersonalLog personalLog)
    {
        try
        {
            var existingPersonalLog = await _personalLogRepository.FindByIdAsync(id);

            if (existingPersonalLog == null)
                return new PersonalLogResponse("PersonalLog not found.");

            existingPersonalLog.Thought = personalLog.Thought;
            existingPersonalLog.Date = personalLog.Date;

            _personalLogRepository.Update(existingPersonalLog);
            await _unitOfWork.CompleteAsync();
            return new PersonalLogResponse(existingPersonalLog);
        }
        catch (Exception e)
        {
            return new PersonalLogResponse($"An error occurred while updating the personalLog: {e.Message}");
        }
    }

    public async Task<PersonalLogResponse> DeleteAsync(int id)
    {
        try
        {
            var existingPersonalLog = await _personalLogRepository.FindByIdAsync(id);

            if (existingPersonalLog == null)
                return new PersonalLogResponse("PersonalLog not found.");

            _personalLogRepository.Remove(existingPersonalLog);
            await _unitOfWork.CompleteAsync();
            return new PersonalLogResponse(existingPersonalLog);
        }
        catch (Exception e)
        {
            return new PersonalLogResponse($"An error occurred while deleting the personalLog: {e.Message}");
        }
    }
}