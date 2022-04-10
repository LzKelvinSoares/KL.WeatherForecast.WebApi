using KL.WeatherForecast.Api.Services;
using KL.WeatherForecast.Api.Services.Handlers;

namespace KL.WeatherForecast
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: Configuration.GetSection("ApplicationName").Value, policy =>
                {
                    policy.WithOrigins(Configuration.GetSection("AllowedHosts").Value);
                });
            });
            services.AddHttpClient(nameof(HttpClient));
            services.AddHttpContextAccessor();
            services.AddTransient<IHttpService, HttpServiceHandler>();
            services.AddTransient<IGeolocationService, GeolocationServiceHandler>();
            services.AddTransient<IWeatherForecastService, WeatherForecastServiceHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(Configuration.GetSection("ApplicationName").Value);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
