using BackgroundServicesApp.Services;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServicesApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult FireAndForget()
        {
            Console.WriteLine("111111");
            var data = new MyBackgroundService();
            //data.ExecuteJob("abc","xyz");
            BackgroundJob.Enqueue(() => data.ExecuteJob("abc", "xyz"));
            Console.WriteLine("111111------");

            return Ok("111111");
        }
        [HttpGet]
        public IActionResult AfterTimeSpan()
        {
            Console.WriteLine("22222222");
            var data = new MyBackgroundService();
            //data.ExecuteJob("abc","xyz");
            BackgroundJob.Schedule(() => data.ExecuteJob("abc", "xyz"),DateTimeOffset.FromUnixTimeSeconds(5));
            BackgroundJob.Schedule(() => data.ExecuteJob("SSsss", "ZZZZ"), DateTimeOffset.FromUnixTimeSeconds(5));

            Console.WriteLine("22222222-------");
            return Ok("2222");
        }
        [HttpGet]
        public IActionResult AddUpdate()
        {
            Console.WriteLine("22222222");
            var data = new MyBackgroundService();
            //RecurringJob.AddOrUpdate("",() => data.ExecuteJob("abc", "xyz"), Cron.Minutely);
            var jobId = BackgroundJob.Enqueue(() => data.ExecuteJob("abc", "xyz"));

            Console.WriteLine("22222222-------");
            return Ok("2222");
        }
        [HttpGet]
        public IActionResult TrackJob()
        {
            //JobStorage.Current.GetConnection();
            //using (var connection = JobStorage.Current.GetConnection())
            //{
            //    var jobData = connection.GetJobData(jobId);
            //    Console.WriteLine($"Job Status: {jobData.State}");
            //}
            return Ok("2222");
        }
    }
}
