using ClozetAPI.Banco;
using ClozetAPI.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BancoContext>((options)=> {

    options.UseSqlServer(builder.Configuration["ConnectionStrings:ClozetDB"]).UseLazyLoadingProxies();

});
builder.Services.AddTransient<DAL<Usuario>>();
builder.Services.AddTransient<DAL<Roupa>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.controllerUsuario();
app.controllerRoupa();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
