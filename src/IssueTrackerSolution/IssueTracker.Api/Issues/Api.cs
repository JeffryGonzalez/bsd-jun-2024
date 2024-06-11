namespace IssueTracker.Api.Issues;

public class Api : ControllerBase
{
    [HttpPost("/software/{id:guid}/issues")]
    public async Task<ActionResult> CreateAnIssueAsync(
         Guid id,
        [FromBody] SubmitIssueRequest request)
    {
        // if that software id doesn't exist, return a 404
        // not worry about that for right now.
        // make sure the request is "Valid" - check the data
        // If it's good, save it to a database
        // Send a response - and maybe a copy of the thing we created.
        var response = new IssueResponse
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Impact = request.Impact,
            Status = IssueStatus.Submitted
        };
        return Ok(response);
    }

    [HttpPost("/software/{id:guid}/issues/questions")]
    public async Task<ActionResult> CreateAQuestionIssueAsync(Guid id)
    {
        return Ok();

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

public enum IssueStatus { Submitted, AssignedToTech, AssignedToHighPriorityTech }
public record IssueResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public IssueImpact Impact { get; set; }
    public IssueStatus Status { get; set; }
}
