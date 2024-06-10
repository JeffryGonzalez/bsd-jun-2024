namespace IssueTracker.SystemTests;

public class UnitTest1
{
    [Fact]
    public void CanAddTenAndTwenty()
    {
        int a = 10; int b = 20;

        int answer = a + b; // can .net add two integers

        Assert.Equal(30, answer);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(10, 2, 12)]
    public void CanAddAnyTwoIntegers(int a, int b, int expected)
    {
        var answer = a + b;

        Assert.Equal(expected, answer);
    }
}