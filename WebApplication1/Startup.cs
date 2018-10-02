using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            switch (Configuration["Database:Type"])
            {
                case "Sqlite": services.AddTransient<IDbConnection>(sp => new SQLiteConnection(Configuration.GetConnectionString("Sqlite"))); break;
                case "SqlServer": services.AddTransient<IDbConnection>(sp => new SqlConnection(Configuration.GetConnectionString("SqlServer"))); break;
                default: throw new System.Exception($"Database type '{Configuration["Database:Type"]}' not supported. [Sqlite/SqlServer]");
            }

            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

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
