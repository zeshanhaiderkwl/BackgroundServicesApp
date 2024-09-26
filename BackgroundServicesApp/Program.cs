using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});
//GlobalConfiguration.Configuration.UseMemoryStorage(new MemoryStorageOptions
//{
//    FetchNextJobTimeout = TimeSpan.FromSeconds(1),
//    CountersAggregateInterval = TimeSpan.FromSeconds(1),
    
//});
// Add Hangfire server
builder.Services.AddHangfireServer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHangfireDashboard();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
