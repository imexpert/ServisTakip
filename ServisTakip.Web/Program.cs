using Autofac.Extensions.DependencyInjection;
using Autofac;
using ServisTakip.Business.DependencyResolvers;
using ServisTakip.Web.Infrastructure;
using Serilog.Context;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationServices(builder.Configuration);

var app = builder.Build();

var context = app.Services.GetService<IHttpContextAccessor>();

// This should be called before any other middleware
app.ConfigureRequestPipeline(context);

app.Run();
