using System.Security.Claims;
using System.Text;
using MeowieAPI.API.Configuration.ColumnWriters;
using MeowieAPI.API.Extensions;
using MeowieAPI.Application;
using MeowieAPI.Infrastructure;
using MeowieAPI.Infrastructure.enums;
using MeowieAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
            NameClaimType = ClaimTypes.Name
            
        };

    });

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddStorage(StorageType.Local);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq(builder.Configuration["Seq:ServerURL"])
    .WriteTo.File("logs/log.txt")
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"),"Logs", needAutoCreateTable: true,
    columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        {"message", new RenderedMessageColumnWriter()},
        {"message_template", new MessageTemplateColumnWriter() },
        {"level", new LevelColumnWriter() },
        {"time_stamp", new TimestampColumnWriter() },
        {"exception", new ExceptionColumnWriter() },
        {"log_event", new LogEventSerializedColumnWriter() },
        {"user_name", new UsernameColumnWriter() }
    }
    )
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();
builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resource")),
    RequestPath = "/resource"
});
//my global exception handler
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseStaticFiles();

app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name", username);
    await next();
});

app.MapControllers();

app.Run();
