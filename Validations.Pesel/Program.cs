﻿using Validations.Pesel.IRepositories;
using Validations.Pesel.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPeselRepository, PeselRepository>();
builder.Services.AddScoped<IPeselUtilityRepository, PeselUtilityRepository>();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
    });
        
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

