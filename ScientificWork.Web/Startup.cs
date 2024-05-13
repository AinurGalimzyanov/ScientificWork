using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ScientificWork.Domain.Admins;
using ScientificWork.Domain.Professors;
using ScientificWork.Domain.Students;
using ScientificWork.Domain.Users;
using ScientificWork.Infrastructure.Abstractions.Interfaces.Email;
using ScientificWork.Infrastructure.Common.Services.Email;
using ScientificWork.Infrastructure.DataAccess;
using ScientificWork.UseCases.Common.Settings;
using ScientificWork.UseCases.Common.Settings.Authentication;
using ScientificWork.UseCases.Common.Settings.Email;
using ScientificWork.UseCases.Users.AuthenticateUser;
using ScientificWork.Web.Infrastructure.Authentication;
using ScientificWork.Web.Infrastructure.Middlewares;
using ScientificWork.Web.Infrastructure.Settings;
using ScientificWork.Web.Infrastructure.Startup;
using ScientificWork.Web.Infrastructure.Startup.Swagger;

namespace ScientificWork.Web;

/// <summary>
/// Entry point for ASP.NET Core app.
/// </summary>
public class Startup
{
    private readonly IConfiguration configuration;

    /// <summary>
    /// Entry point for web application.
    /// </summary>
    /// <param name="configuration">Global configuration.</param>
    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    /// <summary>
    /// Configure application services on startup.
    /// </summary>
    /// <param name="services">Services to configure.</param>
    /// <param name="environment">Application environment.</param>
    public void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment)
    {
        // Swagger.
        services.AddSwaggerGen(new SwaggerGenOptionsSetup().Setup);

        // CORS.
        string[]? frontendOrigin = null;
        // TODO: uncomment if you need to specify additional FrontendOrigins for CORS (if you have an Angular/React/etc project).
        // frontendOrigin = Saritasa.Tools.Common.Utils.StringUtils.NullSafe(configuration["AppSettings:FrontendOrigin"])
        //        .Split(';', StringSplitOptions.RemoveEmptyEntries);
        services.AddCors(new CorsOptionsSetup(
            environment.IsDevelopment(),
            frontendOrigin
        ).Setup);

        // Health check.
        var databaseConnectionString = configuration.GetConnectionString("AppDatabase")
                                       ?? throw new ArgumentNullException("ConnectionStrings:AppDatabase",
                                           "Database connection string is not initialized");
        services.AddHealthChecks()
            .AddNpgSql(databaseConnectionString);

        // MVC.
        services
            .AddControllers()
            .AddJsonOptions(new JsonOptionsSetup().Setup);
        services.Configure<ApiBehaviorOptions>(new ApiBehaviorOptionsSetup().Setup);

        // We need to set the application name to data protection, since the default token
        // provider uses this data to create the token. If it is not specified explicitly,
        // tokens from different instances will be incompatible.
        services.AddDataProtection().SetApplicationName("Application")
            .PersistKeysToDbContext<AppDbContext>();

        var emailSettings = new EmailSettings();
        configuration.Bind(EmailSettings.SectionName, emailSettings);
        services.AddSingleton(Options.Create(emailSettings));
        services.AddScoped<IEmailSender, EmailSender>();

        services.AddScoped<RefreshTokenCreationOptions>();
        // Identity.
        services.AddIdentity<User, AppIdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<RefreshTokenProvider<User>>(AuthenticationConstants.AppLoginProvider);
        services.Configure<IdentityOptions>(new IdentityOptionsSetup().Setup);
        services.AddIdentityCore<Professor>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddIdentityCore<Student>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        services.AddIdentityCore<SystemAdmin>().AddRoles<AppIdentityRole>().AddEntityFrameworkStores<AppDbContext>();

        // JWT.
        var jwtSecretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException("Jwt:SecretKey");
        var jwtIssuer = configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer");
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(new JwtBearerOptionsSetup(
                jwtSecretKey,
                jwtIssuer).Setup
            );

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RegistrationComplete", builder =>
            {
                builder.RequireClaim("registrationComplete", "true");
            });
        });
        // Database.
        services.AddDbContext<AppDbContext>(
            new DbContextOptionsSetup(databaseConnectionString).Setup);
        // services.AddAsyncInitializer<DatabaseInitializer>()
        //    .AddAsyncInitializer<RoleInitializer>();

        // Logging.
        services.AddLogging(new LoggingOptionsSetup(configuration, environment).Setup);

        // Application settings.
        services.Configure<AppSettings>(configuration.GetSection("Application"));

        // HTTP client.
        services.AddHttpClient();

        // Other dependencies.
        Infrastructure.DependencyInjection.AutoMapperModule.Register(services);
        Infrastructure.DependencyInjection.ApplicationModule.Register(services, configuration);
        Infrastructure.DependencyInjection.MediatRModule.Register(services);
        Infrastructure.DependencyInjection.SystemModule.Register(services);
    }

    /// <summary>
    /// Configure web application.
    /// </summary>
    /// <param name="app">Application builder.</param>
    /// <param name="environment">Application environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        app.UseStaticFiles();
        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(new SwaggerUIOptionsSetup().Setup);

        // Custom middlewares.
        app.UseMiddleware<ApiExceptionMiddleware>();

        // MVC.
        app.UseRouting();

        // CORS.
        app.UseCors(CorsOptionsSetup.CorsPolicyName);
        app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            Infrastructure.Startup.HealthCheck.HealthCheckModule.Register(endpoints);
            endpoints.Map("/", context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
            endpoints.MapControllers();
        });
    }
}
