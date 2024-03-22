using _3.Routing_Example.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraints));
});
var app = builder.Build();

//To enable routing we have to call UseRouting(); method.

/*app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    await next(context);
});*/

//Using endpoint before calling UseRouting method won't work!
app.UseRouting();

/*app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    if (endpoint != null)
    {
        await context.Response.WriteAsync($"{endpoint.DisplayName}\n");
    }
    await next(context);
});*/

app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension=txt}", async (context) =>
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files {fileName}.{extension}");
    });

    //for maxlength its maxlength(3) and if both then length(2,5) min and max
    endpoints.Map("employee/profile/{employeename:minlength(3)?}", async (context) =>    //?is optional means if the employeename is not given in url still it will get here.
    {
        if (context.Request.RouteValues.ContainsKey("employeename"))
        {
            string? empName = Convert.ToString(context.Request.RouteValues["employeename"]);
            await context.Response.WriteAsync($"Employee name is : {empName}");
        }
        else
        {
            await context.Response.WriteAsync($"Employee name is not provided");
        }

    });

    endpoints.Map("daily-digest-report/{reportdate:datetime}", async (context) =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"Given date time is : {reportDate.ToShortDateString()}");
    });

    //guid
    endpoints.Map("cities/{cityid:guid}", async (context) =>
    {
       Guid cityId =  Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City information is : {cityId}");
    });

    //Custom route constraint
    endpoints.Map("news/{year}/{month:months}", async (context) =>
    {
        await context.Response.WriteAsync("Custom regex");
    });
});

app.UseEndpoints(endpoints =>
{
    //Add your endpoints here
    //The first argument is url path and the second parameter is HttpContext which is a request delegate.
    endpoints.Map("map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map 1");
    });
    endpoints.Map("map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map 2");
    });

    //Map can be used for every request such as GET, POST, PUT, DELETE etc.
    //If you want to be specific then use MapGet, MapPost etc.

    endpoints.MapGet("getMap", async (context) =>
    {
        await context.Response.WriteAsync("Get Map Request");
    });


    endpoints.MapPost("postMap", async (context) =>
    {
        await context.Response.WriteAsync("Post Map Request");
    });


});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"{context.Request.Path}");
});

app.Run();
