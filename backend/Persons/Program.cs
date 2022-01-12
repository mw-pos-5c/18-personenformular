using Microsoft.OpenApi.Models;

using Persons.Services;

string swaggerVersion = "v1";
string swaggerTitle = "Persons";

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------- ConfigureServices
builder.Services.AddDbContext<PersonsContext>(options => options.UseSqlite("Data Source=Persons.sqlite"));

builder.Services.AddScoped<PersonService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc(swaggerVersion,
        new OpenApiInfo
        {
            Title = swaggerTitle,
            Version = swaggerVersion
        });
});



// -------------------------------------------- ConfigureServices END

var app = builder.Build();

// -------------------------------------------- Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    Console.WriteLine("******** Swagger enabled: http://localhost:5000/swagger (to set as default route: see launchsettings.json)");
    app.UseSwagger();
    app.UseSwaggerUI(x => x.SwaggerEndpoint($"/swagger/{swaggerVersion}/swagger.json", swaggerTitle));
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// -------------------------------------------- Middleware pipeline END

app.Run();
