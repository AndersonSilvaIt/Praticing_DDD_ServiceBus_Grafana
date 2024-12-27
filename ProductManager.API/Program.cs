using FluentValidation;
using MediatR;
using ProductManager.Application.Handlers;
using ProductManager.Application.Interfaces;
using ProductManager.Application.Mappings;
using ProductManager.Application.Validators;
using ProductManager.Infrastructure;
using ProductManager.Infrastructure.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();

builder.Services.AddMediatR(typeof(CreateProductCommandHandler));
builder.Services.AddMediatR(typeof(GetProductByIdQueryHandler));
builder.Services.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
builder.Services.AddAutoMapper(typeof(ProductMappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IServiceBusProducer>(provider => {
	var connectionString = builder.Configuration.GetConnectionString("AzureServiceBus");
	return new ServiceBusProducer(connectionString);
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
