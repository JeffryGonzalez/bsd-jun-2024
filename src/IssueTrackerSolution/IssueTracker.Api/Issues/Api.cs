
namespace IssueTracker.Api.Issues;

public class Api : ControllerBase
{
    [HttpPost("/software/{id:guid}/issues")]
    public async Task<ActionResult> CreateAnIssueAsync(
         Guid id,
        [FromBody] SubmitIssueRequest request)
    {
        // if that software id doesn't exist, return a 404

        return Ok(request);
    }
}


public enum IssueImpact
{
    Question,
    Inconvenience,
    WorkStoppage,
    ProductionStoppage
}

public record SubmitIssueRequest
{
    public string Description { get; set; } = string.Empty;
    public IssueImpact Impact { get; set; } = IssueImpact.Question;
}