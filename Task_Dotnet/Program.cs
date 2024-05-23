using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task_Dotnet.DataContext;
using Task_Dotnet.Hubs;
using Task_Dotnet.IRepo;
using Task_Dotnet.Repo;

var builder = WebApplication.CreateBuilder(args);



///////////////////// SQL Configuration  /////////////////////
builder.Services.AddDbContext<Task_DbContext>(option => option.UseLazyLoadingProxies()
.UseSqlServer(builder.Configuration.GetConnectionString("Myconnect")));


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Signalr injection 
builder.Services.AddSignalR();

///////////////// Dependency Injection //////////////////
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<ISupplierRepo, SupplierRepo>();



//////////////////////////////////  CROS  /////////////////////////////////////
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("MyPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:5500")
        .AllowAnyHeader()
        .WithMethods("GET", "POST")
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();
// URL of RealTime for items class 

app.MapHub<ItemsHub>("/Signalrhub");

app.MapControllers();

app.Run();
