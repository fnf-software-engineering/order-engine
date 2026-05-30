namespace OrderEngine.Shared.Responses;

public class ErrorResponse
{
    public string Message { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Details { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    public ErrorResponse() { }
    
    public ErrorResponse(string message, string code, string? details = null)
    {
        Message = message;
        Code = code;
        Details = details;
        Timestamp = DateTime.UtcNow;
    }
}