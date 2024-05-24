using Application.Abstracts;
using Infrastructure.Concretes;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

//env
builder.Configuration.AddEnvironmentVariables();


// Register SMS Providers
builder.Services.AddScoped<GeocellSmsProvider>();
builder.Services.AddScoped<MagtiSmsProvider>();
builder.Services.AddScoped<TwilioSmsProvider>();

// Register all ISmsProvider implementations
builder.Services.AddScoped<ISmsProvider>(sp => sp.GetRequiredService<GeocellSmsProvider>());
builder.Services.AddScoped<ISmsProvider>(sp => sp.GetRequiredService<MagtiSmsProvider>());
builder.Services.AddScoped<ISmsProvider>(sp => sp.GetRequiredService<TwilioSmsProvider>());

// Register ProviderSelectors
builder.Services.AddScoped<RandomProviderSelector>();
//builder.Services.AddScoped<PercentProviderSelector>();

builder.Services.AddScoped<IProviderSelectorService, ProviderSelectorService>();

// Register ProviderSelectorService
builder.Services.AddSingleton<ProviderSelectorService>();

// Register SmsService
builder.Services.AddTransient<SmsService>();

// Register Dictionary with providers and their respective percentages

builder.Services.AddTransient<Dictionary<ISmsProvider, int>>(sp =>
{
    var providers = sp.GetServices<ISmsProvider>().ToList();
    return new Dictionary<ISmsProvider, int>
    {
        { providers.OfType<MagtiSmsProvider>().First(), 30 },  // Magti - 30%
        { providers.OfType<GeocellSmsProvider>().First(), 25 },  // Geocell - 25%
        { providers.OfType<TwilioSmsProvider>().First(), 45 }   // Twilio - 45%
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sms API", Version = "v1" });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();