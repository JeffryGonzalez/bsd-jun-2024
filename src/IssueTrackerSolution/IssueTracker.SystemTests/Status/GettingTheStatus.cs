
using Alba;
using IssueTracker.Api.Status;

namespace IssueTracker.SystemTests.Status;
public class GettingTheStatus
{
    [Fact]
    public async Task WeCanGetTheStatus()
    {
        // When I do an HTTP GET /status I should...
        // get a 200 Ok status code.
        // I should get back an JSON document with a message, and the time it was created.

        var host = await AlbaHost.For<global::Program>();


        var response = await host.Scenario(api =>
        {
            api.Get.Url("/status");
            api.StatusCodeShouldBeOk();
        });

        var actualResponse = await response.ReadAsJsonAsync<GetStatusResponse>();

        Assert.NotNull(actualResponse);

        Assert.Equal("Looks Good Here!", actualResponse.Message);
        Assert.Equal(DateTimeOffset.UtcNow, actualResponse.LastChecked, TimeSpan.FromMilliseconds(100));
    }
}
