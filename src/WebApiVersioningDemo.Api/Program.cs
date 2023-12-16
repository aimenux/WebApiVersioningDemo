using WebApiVersioningDemo.Api.Extensions;

var app = WebApplication
    .CreateBuilder(args)
    .AddServices()
    .Build();

app.UseSwaggerDoc();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
