
namespace IssueTracker.Api.Issues;

public interface IAssignStatusToIssues
{
    Task<IssueStatus> GetStatusForIssueAsync(SubmitIssueRequest request);
}