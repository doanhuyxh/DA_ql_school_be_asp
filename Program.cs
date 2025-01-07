using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Text;
using BeApi.Services;
using BeApi.Data;
using BeApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables()
    .Build();



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Description = "Please enter a valid JWT token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration.GetValue<string>("Issuer"),
            ValidAudience = configuration.GetValue<string>("Audience"),
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWTKey") ?? ""))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var token = context.Request.Cookies["AccessToken"];

                if (string.IsNullOrEmpty(token) &&
                    context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() != null)
                    token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                context.Token = token;
                return Task.CompletedTask;
            },
            OnChallenge = async context =>
            {
                if (!context.Response.HasStarted)
                {
                    context.HandleResponse();
                    context.Response.StatusCode = 200; // Unauthorized
                    context.Response.ContentType = "application/json";
                    var result = new ResponeDataViewModel(ResponseStatusCode.Unauthorized);
                    await context.Response.WriteAsJsonAsync(result);
                }
            },
            OnForbidden = async context =>
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = 200; // Forbidden
                    context.Response.ContentType = "application/json";
                    var result = new ResponeDataViewModel();
                    await context.Response.WriteAsJsonAsync(result);
                }
            }
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("MSSQL") ?? "")
        .EnableSensitiveDataLogging());
builder.Services.AddTransient<ICommon, Common>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

builder.WebHost.UseUrls("http://127.0.0.1:5000");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var exception = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;
        var errorResponse = new
        {
            code = 500,
            data = "",
            message = "An unexpected error occurred.",
            stacktrace = exception?.StackTrace ?? ""
        };

        await context.Response.WriteAsJsonAsync(errorResponse);
    });
});

app.UseCors("AllowAllOrigins");
app.UseCookiePolicy();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();


app.Run();

