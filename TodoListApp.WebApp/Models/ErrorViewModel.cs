namespace TodoListApp.WebApp.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

#pragma warning disable IDE0009
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
#pragma warning restore IDE0009
}
