using FilmesAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//Configura o servi�o de acesso ao banco(adiciona contexto de banco de dados, o filme context, e as op��es s�o simplesmente utilizar o MySQL, a string de conex�o est� definida em appsettings.json
//A nossa string de conex�o est� definida no json(FilmeConnection)
builder.Services.AddDbContext<FilmeContext>(opts => opts.UseMySQL(builder.Configuration.GetConnectionString("FilmeConnection")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
