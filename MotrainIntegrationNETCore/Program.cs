using MotrainIntegrationNETCore;
using static MotrainIntegrationNETCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Metrics;
using System.Configuration;

class Program
{
    public static string LOGFILENAME = "";
    private static string LogFilePath = ConfigurationSettings.AppSettings["LogFileFolder"];
    private static StreamWriter sw;

    static async Task Main(string[] args)
    {
        try
        {
            var userRepository = new UserRepository();
            var motrainAPI = new MotrainAPI();

            //Get Users and Courses from the DB
            var users = userRepository.GetAllUsers();


            foreach (var user in users)
            {
                if ( user.MotrainStatus == 0)
                {
                    //process the motrain API from here

                    motrainAPI.ProcessMotrainAPI(user.UserID, user.iCSID, user.courseName, user.MotrainStatus, user.coursePoints, user.Email, user.FullName
                        , user.address, user.city, user.state, user.country);
                }
            }
        }
        catch (Exception ex)
        {
            string error = ex.ToString();
            MotrainIntegrationNETCore.Logger.Error(error);
            throw;
        }

        



        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<DataContext>();
                services.AddHttpClient<HttpGetService>();
            })
            .Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var httpService = services.GetRequiredService<HttpGetService>();
            var dataContext = services.GetRequiredService<DataContext>();

            // Example GET request
            string getUrl = "https://fake-json-api.mock.beeceptor.com/companies";
            string getResponse = await httpService.GetAsync(getUrl);
            Console.WriteLine("GET Response: " + getResponse);

            // Example POST request
            string postUrl = "https://jsonplaceholder.typicode.com/posts";
            var content = new StringContent("{\"title\": \"foo\", \"body\": \"bar\", \"userId\": 1}", Encoding.UTF8, "application/json");
            string postResponse = await httpService.PostAsync(postUrl, content);
            Console.WriteLine("POST Response: " + postResponse);

            // Update database
            dataContext.Database.EnsureCreated();
            var item = new Item { Name = "Sample Item" };
            //dataContext.Items.Add(item);
            await dataContext.SaveChangesAsync();
            Console.WriteLine("Database updated.");
        }

        Console.WriteLine("Operation completed.");
    }


    private static void Log(string logString)
    {
        LOGFILENAME = LogFilePath + "log.txt";
        if (!File.Exists(LOGFILENAME))
        {
            sw = File.CreateText(LOGFILENAME);
        }
        else
        {
            sw = File.AppendText(LOGFILENAME);
        }
        sw.WriteLine(logString);
        sw.Close();
    }
}
