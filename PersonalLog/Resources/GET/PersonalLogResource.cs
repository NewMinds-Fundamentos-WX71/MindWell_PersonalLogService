namespace MindWell_PersonalLogService.PersonalLog.Resources.GET;

public class PersonalLogResource
{
    public int Id { get; set; }
    public string Thought { get; set; }
    public DateTime Date { get; set; }
    public int Users_Id { get; set; }
}