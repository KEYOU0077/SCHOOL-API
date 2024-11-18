using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddRazorPages();

        builder.Services.AddControllers();

        builder.Services.AddDbContext<SchoolContext>(options =>
        {
            options.UseSqlServer("Server=KEYOU;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;");
        });

      
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllers();

        app.Run();

    }
}