using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using backend.Context;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoAdm")));    

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();
app.UseRouting();

app.MapControllers();
app.Run();

