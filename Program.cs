// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();


// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
var builder = WebApplication.CreateBuilder(args);

// Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Pizza Data
var pizzas = new List<Pizza>
{
    new Pizza(1, "Margherita", 199),
    new Pizza(2, "Pepperoni", 299),
    new Pizza(3, "Farmhouse", 249),
    new Pizza(4, "Cheese Burst", 349)
};


// Home Route
app.MapGet("/", () =>
{
    return " Welcome to Kaamaashee Pizza Store!";
});


// Get All Pizzas
app.MapGet("/pizzas", () =>
{
    return pizzas;
});


// Get Pizza By Id
app.MapGet("/pizzas/{id}", (int id) =>
{
    var pizza = pizzas.FirstOrDefault(p => p.Id == id);

    if (pizza == null)
    {
        return Results.NotFound("❌ Pizza not found");
    }

    return Results.Ok(pizza);
});


// Special Offer API
app.MapGet("/offer", () =>
{
    return " Today Offer: Buy 1 Get 1 Free!";
});


app.Run();


// Pizza Model
record Pizza(int Id, string Name, int Price);