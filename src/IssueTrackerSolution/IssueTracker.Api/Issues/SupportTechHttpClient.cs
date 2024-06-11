namespace IssueTracker.Api.Issues;

public class SupportTechHttpClient(HttpClient client)
{

    public async Task<SupportInformation> GetSupportPersonAsync(Guid softwareId)
    {
        var response = await client.GetAsync("/techs/" + softwareId);

        response.EnsureSuccessStatusCode(); // If this anything other than 200-299

        var body = await response.Content.ReadFromJsonAsync<SupportInformation>();

        return body!;
    }
}

public record SupportInformation(string Name, string PhoneNumber);