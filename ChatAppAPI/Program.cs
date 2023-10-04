using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ChatAppAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseCors( options:CorsPolicyBuilder => options
            //  .WithOrigins(
            //    new string[]
            //    {
            //        "http://localhost:4200", "http://localhost:8080"
            //    })
            //  .AllowAnyHeader()
            //  .AllowAnyMethod()
            //  );

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200") 
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}