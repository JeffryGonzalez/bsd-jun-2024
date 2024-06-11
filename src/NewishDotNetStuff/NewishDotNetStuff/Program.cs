
using NewishDotNetStuff;

Console.WriteLine("Program is running, yo");

// var c = someApi.GetCustomer(12);

var c = new Customer { Name = "Joe Schmidt", AvailableCredit = 30000M };
var d = new Customer { Name = "Joe Schmidt", AvailableCredit = 30000M };


if (c == d)
{
    Console.WriteLine("They are the same!");
}
else
{
    Console.WriteLine("They are different");
}

//var e = new Customer { Name = d.Name, AvailableCredit = d.AvailableCredit + 100 };
var e = d with { AvailableCredit = d.AvailableCredit + 100 };

//var account = new BankAccount();

//var balance = account.GetBalanceInformation();

//var r = Utils.FormatName("Han", "Solo");



//Console.WriteLine($"Account has {balance.Checking:c} in Checking and {balance.Savings:c} in Savings");

////balance.Checking = 1_000_000M;
//Console.WriteLine($"Account has {balance.Checking:c} in Checking and {balance.Savings:c} in Savings");

//var bob = new NewishDotNetStuff.Hr.Employee();

//bob.Address = new NewishDotNetStuff.Hr.AddressInfo { Street = "Clifton", City = "Lakewood" };


////bob.EmailAddresses.Add("bob@compuserve.com");
//var street = bob.Address?.Street;
//foreach (var email in bob.EmailAddresses)
//{
//    Console.WriteLine(email);
//}

//Console.Write("Add A New Email Address: ");
//var newAddress = Console.ReadLine();

//if (newAddress != null)
//{
//    bob.AddEmailAddress(newAddress);
//}


//foreach (var email in bob.EmailAddresses)
//{
//    Console.WriteLine(email);
//}


