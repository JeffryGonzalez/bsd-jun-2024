

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. - behind the scenes stuff that is our code, or how we are going to connedct
// attached resources (databases, other apis, etc.)


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // after this, phase 2 - we have the "background" stuff set up, now let's talk about
// how we are going to handle incoming requests and make responses.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // the thing that generates our OpenAPI specification (it's a JSON document)
    app.UseSwaggerUI(); // the thing that let's us look at that and interact with it 
}

app.UseAuthorization();

app.MapControllers(); // Using REFLECTION, go make a "route table" (like a phone list.)

// if I get a GET /status - create the Status:Api, Call the Get method
// If I get a POST /sofware/{id:guid}/issues Call the Issues Api method.

app.Run(); // That the application is running. This is a blocking call.

public partial class Program { } // admittedly weird, but this just means I can see the Program class from my tests.