

namespace NewishDotNetStuff;
public class BankAccount
{

    public BalanceInformation GetBalanceInformation()
    {
        // go get the stuff from teh database, whatever

        return new BalanceInformation { Checking = 122.23M, Savings = 0 };
    }
}

public record BalanceInformation
{
    public required decimal Checking { get; init; }
    public required decimal Savings { get; init; }

    public decimal HealthSavings { get; init; }
}


public static class Utils
{

    public static FormattedName FormatName(string firstName, string lastName)
    {
        var fullName = lastName + ", " + firstName;
        var len = fullName.Length;
        return new FormattedName { FullName = fullName, LengthOfName = len };
    }

}

public class FormattedName
{
    public string FullName { get; init; } = string.Empty;
    public int LengthOfName { get; init; }
}