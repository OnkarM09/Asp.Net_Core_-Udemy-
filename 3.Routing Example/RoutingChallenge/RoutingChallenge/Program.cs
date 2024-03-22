using Microsoft.Extensions.Primitives;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    Dictionary<int, string> countreis = new Dictionary<int, string>()
        {
            {1, "UnitedStates"},
            {2, "Russia" },
            {3, "India" },
            {4, "United Kingdom" },
            {5, "Japan" }
        };
    endpoints.MapGet("/", async (context) =>
    {
        await context.Response.WriteAsync("Hello");
    });

    endpoints.MapGet("countries", async (context) =>
    {

        context.Response.StatusCode = 200;
        foreach (KeyValuePair<int, string> country in countreis)
        {
            await context.Response.WriteAsync($"{country.Key}, {country.Value}\n");
        }
    });


    endpoints.MapGet("countries/{id:int:range(1,100)}", async (context) =>
    {
        if (!context.Request.RouteValues.ContainsKey("id"))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync($"No Id Provided!");
        }

        string? id = Convert.ToString(context.Request.RouteValues["id"]);
        int countryId = Convert.ToInt16(id);
        if(countryId < 6)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync($"{countreis[countryId]}");
        }
        else
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync($"No countries available");
        }
    });

    endpoints.MapGet("countries/{id:min(101)}",async (context) =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync($"Id should not be greater than 100");
    });
});

app.Run();
