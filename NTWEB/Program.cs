using Microsoft.EntityFrameworkCore;
using NTWEB;
using NTWEB.Middleware;
using NTWEB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var razorBuilder = builder.Services.AddRazorPages();
builder.Configuration.AddEnvironmentVariables();
var connStr = Environment.GetEnvironmentVariable("MyConnectionString");
builder.Services.AddTransient<IResumeRepository, ResumeRepository>();

builder.Services.AddDbContext<NTWEBContext>(options => options.UseSqlServer(connStr));

builder.Services.AddResponseCompression(options => { options.EnableForHttps = true; });

if (builder.Environment.IsDevelopment())
{
    razorBuilder.AddRazorRuntimeCompilation();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseMiddleware<RequestTimingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
