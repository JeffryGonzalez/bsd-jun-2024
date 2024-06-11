namespace NewishDotNetStuff.Hr;

public class Employee
{
    public IReadOnlyList<string> EmailAddresses { get; set; } = ["Bob@aol.com", "sue@compuserve.com"];


    public void AddEmailAddress(string newAddress)
    {
        // complex logic to validate here..
        EmailAddresses = [newAddress, .. EmailAddresses];
    }

    public AddressInfo? Address { get; set; }


}


public class AddressInfo
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}