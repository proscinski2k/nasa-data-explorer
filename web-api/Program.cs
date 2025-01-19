using Microsoft.OpenApi.Models;
using web_api.Interfaces;
using web_api.Middlewares;
using web_api.Models;
using web_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddHttpClient<IApodService, ApodService>();
builder.Services.AddHttpClient<IOsdrService, OsdrService>();
builder.Services.AddHttpClient<ISatelliteService, SatelliteService>();
builder.Services.AddHttpClient<ISystemService, SystemService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NASA API", Version = "v1" });

    c.AddSecurityDefinition("ClientToken", new OpenApiSecurityScheme
    {
        Description = "Wprowadü Client-Token",
        Name = "Client-Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ClientToken"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

app.UseClientTokenValidation();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
