using MindWell_PersonalLogService.PersonalLog.Domain.Models;
using MindWell_PersonalLogService.PersonalLog.Domain.Repositories;
using MindWell_PersonalLogService.PersonalLog.Services;
using MindWell_PersonalLogService.Shared.Persistence.Repositories;
using Moq;

namespace MindWell_PersonalLogServiceTesting;

public class UnitTest1
{
    [Fact]
    public async Task GetByIdAsync_WhenPersonalLogExists_ReturnsPersonalLog()
    {
        // Arrange
        var mockPersonalLogRepository = new Mock<IPersonalLogRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var personalLogService = new PersonalLogService(mockPersonalLogRepository.Object, mockUnitOfWork.Object);

        int personalLogId = 1;
        var expectedPersonalLog = new PersonalLog
            { Id = personalLogId, Thought = "Sample thought", Date = "2024-05-24" };

        mockPersonalLogRepository.Setup(repo => repo.FindByIdAsync(personalLogId))
            .ReturnsAsync(expectedPersonalLog);

        // Act
        var actualPersonalLog = await personalLogService.GetByIdAsync(personalLogId);

        // Assert
        Assert.NotNull(actualPersonalLog);
        Assert.Equal(expectedPersonalLog.Id, actualPersonalLog.Id);
        Assert.Equal(expectedPersonalLog.Thought, actualPersonalLog.Thought);
        Assert.Equal(expectedPersonalLog.Date, actualPersonalLog.Date);
    }

    [Fact]
    public async Task GetByIdAsync_WhenPersonalLogDoesNotExist_ReturnsNull()
    {
        // Arrange
        var mockPersonalLogRepository = new Mock<IPersonalLogRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var personalLogService = new PersonalLogService(mockPersonalLogRepository.Object, mockUnitOfWork.Object);

        int personalLogId = 1;

        mockPersonalLogRepository.Setup(repo => repo.FindByIdAsync(personalLogId))
            .ReturnsAsync((PersonalLog)null);

        // Act
        var actualPersonalLog = await personalLogService.GetByIdAsync(personalLogId);

        // Assert
        Assert.Null(actualPersonalLog);
    }
}