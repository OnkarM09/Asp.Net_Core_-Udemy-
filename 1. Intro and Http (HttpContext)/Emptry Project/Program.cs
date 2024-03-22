using Microsoft.Extensions.Primitives;
using System.IO;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*app.MapGet("/", () => "Hello World!");*/
app.Run(async (HttpContext context) =>
{
    context.Response.Headers["FirstHeader"] = "Headers 1";          //Headers is a dictionary hence FirstHeader is name of key and Headers 1 is the value.

    /*   string path = context.Request.Path;
       context.Response.StatusCode = 200;
       context.Response.Headers["Content-type"] = "text/html";
       await context.Response.WriteAsync($"{path}");
       await context.Response.WriteAsync("<h1>This is header</h1>");

       if (context.Request.Query.ContainsKey("id"))
       {
           string id = context.Request.Query["id"];    
           await context.Response.WriteAsync($"id={id}");
       }*/

    /*    System.IO.StreamReader reader = new StreamReader(context.Request.Body);
        string body = await reader.ReadToEndAsync();
        Dictionary<string, StringValues> queryDict =  Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
        if (queryDict.ContainsKey("id"))
        {
            await context.Response.WriteAsync($"The passed query string is {queryDict["id"]}");
        }*/

    //Creating app caulculator using query string
    string firstNum ="", secondNum ="";
    int output = 0;
    if (context.Request.Query.ContainsKey("firstParam")
    )
    {
        firstNum = context.Request.Query["firstParam"];
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("First parameter is required!");
    }
    if (context.Request.Query.ContainsKey("secondParam"))
    {
        secondNum = context.Request.Query["secondParam"];
    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Second parameter is required!");
    }
    if (context.Request.Query.ContainsKey("operation"))
    {
        string op= context.Request.Query["operation"];
        int fNum = 0, sNum = 0;
        fNum = Convert.ToInt32(firstNum);
        sNum = Convert.ToInt32(secondNum);
        switch (op)
        {
            case "add":
                {
                    output = fNum + sNum;       
                    await context.Response.WriteAsync($"The addition is {output}");
                    break;
                }
            case "sub":
                {
                    output = fNum - sNum;
                    await context.Response.WriteAsync($"The substraction is {output}");
                    break;
                }
            case "multiply":
                {
                    output = fNum * sNum;
                    await context.Response.WriteAsync($"The multiplication is {output}");
                    break;
                }
            case "divide":
                {
                    output = fNum/sNum;
                    await context.Response.WriteAsync($"The division is {output}");
                    break;
                }
            case "mod":
                {
                    output = fNum % sNum;
                    await context.Response.WriteAsync($"The modulus is {output}");
                    break;
                }
            default:
                {
                    await context.Response.WriteAsync("Invalid paramenters!");
                    break;
                }
        }

    }
    else
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Operator parameter is required!");
    }
});

app.Run();

/*Dictionary<string, int> dict1 = new Dictionary<string, int>();
dict1.Add("key1", 1);
dict1.Add("key2", 2);*/
