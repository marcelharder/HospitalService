namespace HospitalService.Extensions;

    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

           
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.Configure<ComSettings>(config.GetSection("ComSettings"));

            /*          services.AddDbContext<DataContext>(options => options
                       .UseMySql(config.GetConnectionString("SQLConnection"),
                           mysqlOptions =>
                               mysqlOptions.ServerVersion(new Pomelo.EntityFrameworkCore.MySql.Storage.ServerVersion(new Version(10, 4, 6), ServerType.MariaDb)).EnableRetryOnFailure()));
        */
            services.AddSingleton<DapperContext>();
            services.AddScoped<reportMapper>();
            services.AddScoped<IHospitalRepository,HospitalRepo>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
    }
