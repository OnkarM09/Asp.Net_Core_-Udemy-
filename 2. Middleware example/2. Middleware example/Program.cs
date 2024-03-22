using _2._Middleware_example.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();  //Registering custom middleware
builder.Services.AddTransient<CustMiddleware1>();
var app = builder.Build();  //app gets an instance of createbuilder and now we can use app to create middleware

app.MapGet("/", () => "Hello World!");

//One of the methods to create middleware is Run() method.
/*app.Run(async (HttpContext context) =>  //()=> this is called as lambda expression and here it will only execute when it recieves request .ie. it will not execute when appliction starts.
{
    await context.Response.WriteAsync("Hello");
});*/

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello\n");
    await next(context);
});

//Here Use() method can pass request to the next middleware or it can terminate the middleware by passing second argument to the lambda expression,
//The first argument is always HttpContext and second argument is optional which is used the subsequent middleware which is present after.
//Using next and providing context is important becuase the next middleware which will be executed needs HttpContext and for that we pass it from next method.

//Custom Middleware
app.UseMiddleware<MyCustomMiddleware>();
//app.UseMiddleware<CustMiddleware1>();
//app.UseMyCustMiddleware();  //This is an extension which added dynamically

/*app.UseNameMiddleware();*/
//app.UseCustMiddleware1();

//middleware 2
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello again\n");
});

//Catch : app.run won't run again because we have created this middleware using app.Run() middleware
//And .Run() methods nature that it doesn't forward request to the next middleware

app.Run();
