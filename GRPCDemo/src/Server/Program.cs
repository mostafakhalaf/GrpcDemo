using Server.Services;

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
// Add services to the container.

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
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<TelemetryTrackingService>();
    if (app.Environment.IsDevelopment())
    {
        endpoints.MapGrpcReflectionService();
    }
    endpoints.MapControllers();
});
//app.MapControllers();
app.Run();
