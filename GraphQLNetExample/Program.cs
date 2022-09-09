using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLNetExample.Context;
using GraphQLNetExample.Schema;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NotesContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    //opt.UseSqlServer("Server=localhost;Database=graphqltutorial;User Id=sa;Password=Arrietty04#;");
});
builder.Services.AddSingleton<ISchema, NotesSchema>(s => new NotesSchema(new SelfActivatingServiceProvider(s)));
builder.Services.AddGraphQL(o => { o.EnableMetrics = true; })
    .AddSystemTextJson();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GraphQLNetExample", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLNetExample v1"));
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseGraphQL<ISchema>();
app.Run();
