using DemoBinding.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(FakeGenericRepository<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(DbGenericRepository<>));
builder.Services.AddScoped<DbContext, DemoDbContext>(); 
builder.Services.AddDbContext<DemoDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DbContext>(); 
    //context.Database.EnsureDeleted();
    context.Database.Migrate();
}

    // Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
