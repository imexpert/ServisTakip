using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog.Context;
using ServisTakip.Api.Infrastructure;
using ServisTakip.Business.DependencyResolvers;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

//Custom Services
builder.Services.AddCustomServices(builder.Configuration);

builder.Services.AddCustomAuthentication(builder.Configuration);

//add basic MVC feature
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddCustomMediatR();

builder.Services.AddCustomCacheServices();

builder.Services.AddServisTakipDbContext();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new AutofacBusinessModule()));

var app = builder.Build();

// This should be called before any other middleware
app.UseForwardedHeaders();

// VERY IMPORTANT. Since we removed the build from AddDependencyResolvers, let's set the Service provider manually.
// By the way, we can construct with DI by taking type to avoid calling static methods in aspects.
ServiceTool.ServiceProvider = app.Services;

app.ConfigureCustomExceptionMiddleware();

//await app.UseDbOperationClaimCreator();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "Servis Takip Api");
    c.DocExpansion(DocExpansion.None);
});

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Use(async (httpContext, next) =>
{
    LogContext.PushProperty("UserMail", Utils.Email);
    LogContext.PushProperty("UserId", Utils.UserId);
    LogContext.PushProperty("CompanyId", Utils.CompanyId);
    LogContext.PushProperty("ClientIp", httpContext.Connection.RemoteIpAddress);

    await next.Invoke();
});

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();