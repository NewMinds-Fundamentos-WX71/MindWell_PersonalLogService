namespace MindWell_PersonalLogService.PersonalLog.Resources.POST;

public class SavePersonalLogResource
{
    public string Thought { get; set; }
    public DateTime Date { get; set; }
    public int Users_Id { get; set; }
}