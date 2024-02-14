using Microsoft.EntityFrameworkCore;
using Quartz;
using Rosneft.DAL;
using Rosneft.WebApplication.Jobs;
using Rosneft.WebApplication.Odata;
using Rosneft.WebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RosneftDbContext>(options =>
    options.UseSqlServer(conn));

// В чем отличие AddTransient от AddScoped
builder.Services.AddTransient<IConventionModelFactory, EdmModelFactory>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRequestCardExpiredService, RequestCardExpiredService>();

builder.Services.AddQuartz(quartConfig =>
{
    var jobKey = new JobKey(nameof(RequestCardExpiredJob));
    quartConfig.AddJob<RequestCardExpiredJob>(jobConfig => jobConfig.WithIdentity(jobKey));
    quartConfig.AddTrigger(triggerConfig => triggerConfig
    .ForJob(jobKey)
    .WithIdentity(nameof(RequestCardExpiredJob) + "-trigger")
    .WithCronSchedule("0 0/3 * * * ?"));
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
