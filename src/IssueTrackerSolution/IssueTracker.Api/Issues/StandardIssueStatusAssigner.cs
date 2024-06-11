
namespace IssueTracker.Api.Issues;

public class StandardIssueStatusAssigner : IAssignStatusToIssues
{
    public async Task<IssueStatus> GetStatusForIssueAsync(SubmitIssueRequest request)
    {
        if (request.Impact == IssueImpact.WorkStoppage)
        {
            return IssueStatus.AssignedToTech;
        }
        if (request.Impact == IssueImpact.ProductionStoppage)
        {
            return IssueStatus.AssignedToHighPriorityTech;
        }
        return IssueStatus.Submitted;
    }
}
