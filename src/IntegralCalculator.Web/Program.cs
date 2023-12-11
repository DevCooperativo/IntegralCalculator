using IntegralCalculator.Web.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.Run();