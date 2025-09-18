using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.Infra.Authn;
using AluraIdentity6Api.Infra.Data.Database;
using AluraIdentity6Api.Infra.Startup;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataMappers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

builder.Services.ConfigureIdentity();
builder.Services.AddAuthnConfiguration();

builder.Services.AddAppServices();
builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddExceptionHandler(options =>
{
    options.ExceptionHandler = async context =>
    {
        var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

        if (exception is null) return;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new 
        {
            Message = "An unexpected error occurred.",
            Details = exception.Message
        };

        await context.Response.WriteAsJsonAsync(response);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHsts();
app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
