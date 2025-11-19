using MCommunityWeb.Models.ApiModels;
using MCommunityWeb.Services;
using MCommunityWeb.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure HttpClient factory for MCommunityApiClient
builder.Services.AddHttpClient<IMCommunityApiClient, MCommunityApiClient>(client =>
{
    client.BaseAddress = new Uri("https://mcommunity.umich.edu/api/");
});

// Configure MCommunity API options
builder.Services.Configure<MCommunityApiOptions>(
    builder.Configuration.GetSection("MCommunityApi"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
