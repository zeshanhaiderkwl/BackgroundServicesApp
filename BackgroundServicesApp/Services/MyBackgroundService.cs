using Hangfire;

namespace BackgroundServicesApp.Services
{

    public class MyBackgroundService
    {
        public void ExecuteJob(string a, string b)
        {
            Console.WriteLine("First value: " + a);
            Thread.Sleep(1000 * 15); // Simulate a delay of 30 seconds
            Console.WriteLine("Second value: " + b);
          //  BackgroundJob.Enqueue(() => new MyBackgroundService().ExecuteJob("", ""));
        }
        public void ScheduleNextJob()
        {
            // Schedule the next job after 35 seconds
            BackgroundJob.Schedule(() => ExecuteJob("Value1", "Value2"), TimeSpan.FromSeconds(35));

            // Optionally, call this to ensure job is continuously scheduled every 35 seconds
            BackgroundJob.Schedule(() => ScheduleNextJob(), TimeSpan.FromSeconds(35));
        }
    }
}
