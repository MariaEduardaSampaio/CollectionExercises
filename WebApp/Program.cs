
using WebApp.Options;
using WebApp.Services;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<ListContentService>();
            builder.Services.AddTransient<HotPotatoService>();
            builder.Services.AddTransient<ExpressionService>();
            builder.Services.AddTransient<TextStatisticsService>();
            
            builder.Services.AddControllers();
            builder.Services.AddHttpClient();

            builder.Services.AddOptions<TextStatisticsOption>()
                .Bind(builder.Configuration.GetSection(TextStatisticsOption.Section)).ValidateDataAnnotations();
            builder.Services.AddOptions<ListOption>()
                .Bind(builder.Configuration.GetSection(ListOption.Section)).ValidateDataAnnotations();
            builder.Services.AddOptions<HotPotatoOption>()
                .Bind(builder.Configuration.GetSection(HotPotatoOption.Section)).ValidateDataAnnotations();
            builder.Services.AddOptions<ExpressionOption>()
                .Bind(builder.Configuration.GetSection(ExpressionOption.Section)).ValidateDataAnnotations();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
