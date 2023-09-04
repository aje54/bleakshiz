using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using bleakshiz.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BleakshizArtContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("BleakshizArtContext")));
}
else
{
    builder.Services.AddDbContext<BleakshizArtContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionBleakshizArtContext")));
}


//builder.Services.AddDbContext<BleakshizArtContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("BleakshizArtContext") ?? throw new InvalidOperationException("Connection string 'BleakshizArtContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

