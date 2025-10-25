using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using NTWEB;
using NTWEB.Middleware;
using NTWEB.Repositories;
using NTWEB.Services;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var razorBuilder = builder.Services.AddRazorPages();
builder.Configuration.AddEnvironmentVariables();
var connStr = Environment.GetEnvironmentVariable("MyConnectionString");

builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
builder.Services.AddSingleton<EmailService>();

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
app.UseMiddleware<RequestTimingMiddleware>();

app.UseHttpsRedirection();

app.UseResponseCompression();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
    }
});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
