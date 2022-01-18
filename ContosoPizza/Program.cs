using ContosoPizza.Data;
using ContosoPizza.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<PersonContext>("Data Source=MorePerson.db");
builder.Services.AddScoped<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

List<Person> persons = ReadingCSV.ReadPersons(@"E:\Projekte\C#\HelloWorld\sample-input.csv");
app.AddData(persons);

app.Run();