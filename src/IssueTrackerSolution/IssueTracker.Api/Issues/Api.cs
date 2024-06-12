using Marten;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Api.Issues;

public class Api(IDocumentSession session, IAssignStatusToIssues statusAssigner, SupportTechHttpClient supportApi) : ControllerBase
{



    [HttpPost("/software/{id:guid}/issues")]
    public async Task<ActionResult> CreateAnIssueAsync(
         Guid id,
        [FromBody] SubmitIssueRequest request)
    {
        // if that software id doesn't exist, return a 404
        // not worry about that for right now.
        // make sure the request is "Valid" - check the data
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // If it's good, save it to a database
        // Send a response - and maybe a copy of the thing we created.
        var response = new IssueResponse
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Impact = request.Impact.Value,
            Status = await statusAssigner.GetStatusForIssueAsync(request) // WTCYWYH
        };
        // if the status is high proirity blah blah
        // call into another API (Microservice!) that we will build 
        // and get the contact information.
        // GET http://otherapi/techs/{id}
        if (response.Status == IssueStatus.AssignedToHighPriorityTech)
        {
            var supportInfo = await supportApi.GetSupportPersonAsync(id);
            response.SupportInformation = supportInfo;
        }


        session.Store(response);
        await session.SaveChangesAsync();
        return Ok(response);
    }

    [HttpGet("/software/{id:guid}/issues/{issueId:guid}")]
    public async Task<ActionResult> GetIssueAsync(Guid id, Guid issueId)
    {

        var savedIssue = await session.Query<IssueResponse>()
            .Where(iss => iss.Id == issueId)
            .SingleOrDefaultAsync(); // this should return zero or 1 issue.

        if (savedIssue == null)
        {
            return NotFound(); // 404
        }
        else
        {
            return Ok(savedIssue);
        }
    }

    [HttpGet("/software/{id:guid}/issues")]
    public async Task<ActionResult> GetAllIssuesFor()
    {
        var issues = await session.Query<IssueResponse>().ToListAsync();

        return Ok(new { issues, page = 1, of = 10 });
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
    [Required, MinLength(3), MaxLength(512)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public IssueImpact? Impact { get; set; }

    [Required]
    public string MothersMaidenName { get; set; } = string.Empty;
}

public enum IssueStatus { Submitted, AssignedToTech, AssignedToHighPriorityTech }
public record IssueResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public IssueImpact Impact { get; set; }
    public IssueStatus Status { get; set; }
    public SupportInformation? SupportInformation { get; set; }
}
