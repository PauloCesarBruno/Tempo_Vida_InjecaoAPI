using Tempo_Vida_InjecaoAPI.Interfaces;
using Tempo_Vida_InjecaoAPI.Services;

namespace Tempo_Vida_InjecaoAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Foram Registrados os 3 tipos de tempo de vida de Injeção de dependência.
        builder.Services.AddTransient<ITransientService, TransientSevice>();
        builder.Services.AddScoped<IScopedService, ScopeddService>();
        builder.Services.AddSingleton<ISingetonService, SingletonService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
