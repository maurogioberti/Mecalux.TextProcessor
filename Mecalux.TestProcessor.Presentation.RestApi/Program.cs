using Mecalux.TestProcessor.Business.Logic;
using Mecalux.TestProcessor.Business.Logic.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Mappers;
using Mecalux.TestProcessor.ResourceAccess.Mappers.Abstractions;
using Mecalux.TestProcessor.ResourceAccess.Repositories;
using Mecalux.TestProcessor.ResourceAccess.Repositories.Abstractions;
using Mecalux.TestProcessor.Services;
using Mecalux.TestProcessor.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TextService
builder.Services.AddTransient<ITextService, TextService>();
builder.Services.AddTransient<ITextLogic, TextLogic>();
builder.Services.AddTransient<ITextRepository, TextRepository>();
builder.Services.AddTransient<ITextMapper, TextMapper>();

//TextSortService
builder.Services.AddTransient<ITextSortService, TextSortService>();
builder.Services.AddTransient<ITextSortLogic, TextSortLogic>();
builder.Services.AddTransient<ITextSortRepository, TextSortRepository>();
builder.Services.AddTransient<ITextSortMapper, TextSortMapper>();
builder.Services.AddControllers();

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