namespace ResumeApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using ResumeApi.Repositories;
    using ResumeApi.Repositories.EntityFramework;
    using ResumeApi.RepositoryInterfaces;
    using StructureMap;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<ResumeContext>(options =>
                options.UseNpgsql(sqlConnectionString));

            services.AddMvc();
        }

        public void ConfigureContainer(Registry registry)
        {
            registry.For<IResumeRepository>().Use<ResumeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}