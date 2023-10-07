
using Microsoft.EntityFrameworkCore;
using Repository_Pattern.core.Interfaces;
using Repository_Pattern.EF;
using Repository_Pattern.EF.Repositries;
namespace ResopositryPatternWithUOW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var cn = builder.Configuration.GetConnectionString("DefualtConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cn,
            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
           
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient(typeof(Irepositiry<>), typeof(repositiry<>));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}