using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
            builder => builder
         .WithOrigins("https://localhost:7138")
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials()
         .SetPreflightMaxAge(TimeSpan.FromSeconds(86400)));
        });




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
//enable cors
app.UseCors("AllowSpecificOrigin");
app.UseRouting();
//// global cors policy
//			app.UseCors(x => x
//				.AllowAnyOrigin()
//				.AllowAnyMethod()
//                .AllowAnyHeader());

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute( 
        name: "default",
        pattern: "{controller=User}/{action=Index}/{id?}");
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
