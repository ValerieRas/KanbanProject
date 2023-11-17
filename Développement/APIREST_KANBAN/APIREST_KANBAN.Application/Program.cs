
using KANBAN.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Kaban.Data.Context.Contrat;
using Kaban.Data.Repository;
using Kaban.Data.Repository.Contrat;
using Kaban.Business.Service;
using Kaban.Business.Service.Contrat;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

//Connection string to the DataBase

string? connectionString = configuration.GetConnectionString("BddConnection");
builder.Services.AddDbContext<IKabanDBContext, KanbanDBContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "http://localhost:3001")
                                .AllowAnyHeader()
                                .AllowAnyMethod();

                      });
});


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IActionTacheRepository, ActionTacheRepository>();
builder.Services.AddScoped<IObjectifProjetRepository, ObjectifProjetRepository>();
builder.Services.AddScoped<IProjetRepository, ProjetRepository>();
builder.Services.AddScoped<IStatutRepository, StatutRepository>();
builder.Services.AddScoped<ITacheRepository, TacheRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();


builder.Services.AddScoped<IActionTacheService, ActionTacheService>();
builder.Services.AddScoped<IObjectifProjetService, ObjectifProjetService>();
builder.Services.AddScoped<IProjetService, ProjetService>();
builder.Services.AddScoped<IStatutService, StatutService>();
builder.Services.AddScoped<ITacheService, TacheService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);



app.UseAuthorization();

app.MapControllers();

app.Run();
