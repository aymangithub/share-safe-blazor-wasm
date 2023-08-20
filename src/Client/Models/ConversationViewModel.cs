namespace FSH.BlazorWebAssembly.Client.Models;


public class BaseConversationViewModel
{
    public long Id { get; set; }
    public long Timestamp { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public bool Deleted { get; set; }

    public DateTime CreatedDate { get; set; }

}
public class ConversationViewModel : BaseConversationViewModel
{
}