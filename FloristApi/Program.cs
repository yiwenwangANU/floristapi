using FloristApi.Data;
using FloristApi.Integrations.Payment;
using FloristApi.Middlewares;
using FloristApi.Repositories;
using FloristApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Stripe;
using Stripe.TestHelpers;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:floristapi:sqldb"]));

builder.Services.AddAzureClients(azureBuilder =>
{
    azureBuilder.AddBlobServiceClient(builder.Configuration["ConnectionStrings:floristapi:storage"]);
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => { 
    options.Password.RequiredLength = 6;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// parse string in json for enum
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Enable CORS
var corsOrigins = builder.Configuration
    .GetSection("Cors:Origins")
    .Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(corsOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


builder.Services.AddScoped<IFlowerRepository, FlowerRepository>();
builder.Services.AddScoped<IFlowerReadService, FlowerReadService>();
builder.Services.AddScoped<IFlowerWriteService, FlowerWriteService>();

builder.Services.AddScoped<IPlantRepository, PlantRepository>();
builder.Services.AddScoped<IPlantReadService, PlantReadService>();
builder.Services.AddScoped<IPlantWriteService, PlantWriteService>();

builder.Services.AddScoped(typeof(IGiftRepository<>), typeof(GiftRepository<>));
builder.Services.AddScoped(typeof(IGiftReadService<>), typeof(GiftReadService<>));
builder.Services.AddScoped(typeof(IGiftWriteService<>), typeof(GiftWriteService<>));

builder.Services.AddScoped<IBlobService, BlobService>();

StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.Configure<StripeModel>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<Stripe.CustomerService>();
builder.Services.AddScoped<ChargeService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<PriceService>();

builder.Services.AddScoped<IStripeService, StripeService>();
var app = builder.Build();

// serve wwwroot (default) => /uploads/... will be public
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger middleware
    app.UseSwaggerUI(); // Enable Swagger UI middleware
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowFrontend");
app.UseAuthorization();

app.MapControllers();

app.Run();
