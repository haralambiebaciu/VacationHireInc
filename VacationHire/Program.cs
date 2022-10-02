using Web;
using MediatR;
using Domain.Abstractions;
using Infrastructure.Repositories.Implementations;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Application.Abstractions.Currency;
using Infrastructure.Services;
using Infrastructure.Configs;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var presentationAssembly = typeof(AssemblyReference).Assembly;
var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

builder.Services.AddControllers()
    .AddApplicationPart(presentationAssembly)
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddMediatR(applicationAssembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VacationHire"),
                                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)),
                ServiceLifetime.Transient);
builder.Services.AddScoped<IDbConnection>(factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IVehicleBillRepository, VehicleBillRepository>();
builder.Services.AddScoped<IVehicleItemRepository, VehicleItemRepository>();

var currencyApiSettings = new CurrencyApiSettings();
builder.Configuration.Bind("CurrencyApi", currencyApiSettings);
builder.Services.AddSingleton(currencyApiSettings);

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICurrencyClient, CurrencyClient>((serviceProvider, client) =>
{
    var settings = serviceProvider.GetRequiredService<CurrencyApiSettings>();
    var uriBuilder = new UriBuilder(settings.BaseAddress)
    {

        // Make sure we're sending over a secure channel
        Scheme = "https",
        Port = 443
    };

    client.BaseAddress = uriBuilder.Uri;
    client.DefaultRequestHeaders.Add("apikey", settings.ApiKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
