using ConvertExcelToObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

IParser parser = new ExcelParser();
parser.ParseFile(@"F:\Documents\Software\C#\ConvertExcelToObjects\ConvertExcelToObjects\GT wins sample data.xlsx");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapGet("/", () => "Hello world");
    //app.MapGet("/weather", () =>
    //{
    //    var forecast = Enumerable.Range(0, 10).Select(index => new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(index)), Random.Shared.Next(-5, 5), ""));
    //});
}

app.MapPost("/user/files/{spreadsheet}.xlsx", () =>
{

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
