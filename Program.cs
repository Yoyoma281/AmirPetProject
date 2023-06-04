using AmirPetProject.Data;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
        builder.Services.AddDbContext<DB>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

        builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
        builder.Services.AddScoped<IAnimelEdit, AnimalEdit>();
        builder.Services.AddControllersWithViews();
        var app = builder.Build();

        //app.UseStaticFiles(new StaticFileOptions
        //{
        //    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "StaticFiles")),
        //    RequestPath = "/StaticFiles"
        //});

        using (var scope = app.Services.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<DB>();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
        
        var options = new DbContextOptionsBuilder<DB>()
            .UseSqlServer(connectionString)
            .Options;


        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        app.Run();
    }
        
}