using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Status;

public class Api : ControllerBase
{
    // GET /status
    [HttpGet("/status")]
    public async Task<ActionResult> GetTheStatusAsync() // Slime
    {
        var response = new GetStatusResponse("Looks Good Here!", DateTimeOffset.UtcNow);
        //{
        //   Message = "Looks Good",
        //   LastChecked = DateTimeOffset.UtcNow
        //};
        return Ok(response); // 
    }
}

public record GetStatusResponse(string Message, DateTimeOffset LastChecked);
//public record GetStatusResponse
//{
//    public required string Message { get; init; } = string.Empty;
//    public required DateTimeOffset LastChecked { get; init; }
//}