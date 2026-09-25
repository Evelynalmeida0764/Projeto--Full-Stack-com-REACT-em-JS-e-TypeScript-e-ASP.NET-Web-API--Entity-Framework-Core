var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Código para configuração do Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    // Código que permite usar o Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapOpenApi();
}

app.MapControllers();

//app.UseHttpsRedirection();


app.Run();
