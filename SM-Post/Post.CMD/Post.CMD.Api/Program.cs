using Post.CMD.Infrastructure.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBConfig>(builder.Configuration.GetSection(nameof(MongoDBConfig)));

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
