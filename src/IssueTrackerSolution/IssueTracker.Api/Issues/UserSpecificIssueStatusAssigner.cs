

namespace IssueTracker.Api.Issues;

public class UserSpecificIssueStatusAssigner : IAssignStatusToIssues
{
    public Task<IssueStatus> GetStatusForIssueAsync(SubmitIssueRequest request)
    {
        throw new NotImplementedException();
    }
}
