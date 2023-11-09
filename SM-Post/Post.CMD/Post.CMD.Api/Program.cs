using CQRS.Core.Domain;
using CQRS.Core.Infrastructure;
using Post.CMD.Infrastructure.Config;
using Post.CMD.Infrastructure.Repositories;
using Post.CMD.Infrastructure.Stores;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBConfig>(builder.Configuration.GetSection(nameof(MongoDBConfig)));
builder.Services.AddScoped<IEventStoreRepository, EventStoreRepository>();
builder.Services.AddScoped<IEventStore, EventStore>();

builder.Services.AddControllers();
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
