using EmployeeManagement.Client;
using EmployeeManagement.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;



namespace EmployeeManagement.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);


            builder.Services.AddAutoMapper(typeof(EmployeeProfile));
            
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7213/");

            });

            builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7213/");

            });

            builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}