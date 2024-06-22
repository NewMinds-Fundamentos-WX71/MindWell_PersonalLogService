namespace MindWell_PersonalLogService.PersonalLog.Domain.Models;

public class PersonalLog
{
    public int Id { get; set; }
    public string Thought { get; set; }
    public DateTime Date { get; set; }
    public int Users_Id { get; set; }
}