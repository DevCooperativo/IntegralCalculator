using IntegralCalculator.Web.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

//serviços:
//mvc e razor runtime compilation
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureServices(builder.Configuration);
builder.WebHost.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseUrls("https://devcoop.com.br:7143");

var app = builder.Build();


//pipeline:
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