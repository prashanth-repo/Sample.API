using Sample.API.Service;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IBusinessComponent, BusinessComponent>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GWP Web Api - Backend assesment", Version = "v1" });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   // app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GWP Web Api - Backend assesment v1"));

}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
