using api.Data;
using api.Middleware;
using api.Repositories;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// CORS rules for development
var allowrRules = "_allowRules";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowrRules,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen(c =>
// {
//     var xmlFile = Path.Combine(AppContext.BaseDirectory, "api.xml");
//     c.IncludeXmlComments(xmlFile);
// });

builder.Services.AddSwaggerGen();



// Dependencies
builder.Services.AddScoped<IProductRepository, ProductRepository>();



var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors(allowrRules);

app.MapControllers();

app.Run();

