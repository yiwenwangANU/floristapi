using FloristApi.Data;
using FloristApi.Middlewares;
using FloristApi.Repositories;
using FloristApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
                                                  .AllowCredentials()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

builder.Services.AddScoped<IFlowerRepository, FlowerRepository>();
builder.Services.AddScoped<IFlowerService, FlowerService>();
builder.Services.AddScoped<IBlobService, BlobService>();
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
