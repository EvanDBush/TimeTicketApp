using Microsoft.EntityFrameworkCore;
using TimeTicketApp.Data;

namespace TimeTicketAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddDbContext<TimeTicketContext>(opt =>
                opt.UseSqlite(Configuration.GetConnectionString("TimeTicketConnex"))
                .EnableSensitiveDataLogging(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
