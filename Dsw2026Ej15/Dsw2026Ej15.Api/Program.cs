
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            //         builder.Services.AddHealthChecks();
            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();
            //registrar la persistencia como singleton, es decir, se crea una única instancia de PersistenceInMemory que se comparte en toda la aplicación. Esto es útil para mantener el estado en memoria durante la ejecución de la aplicación.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //app.MapOpenApi();
                app.UseSwaggerUI();
            }


            //            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseAuthorization();

            app.MapControllers();
            //          app.MapHealthChecks("/health-check");
            //saber si esta funcionando o no la aplicación,
            //se puede acceder a esta ruta para verificar el estado de salud de la aplicación.
            app.Run();
        }
    }
}