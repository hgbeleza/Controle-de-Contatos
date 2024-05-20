using CadastroContatos.Data;
using CadastroContatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace CadastroContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectString = builder.Configuration.GetConnectionString("DataBase");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Database connection
            builder.Services.AddDbContext<BancoContext>(options =>
            {
                options.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
            });
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

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
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
