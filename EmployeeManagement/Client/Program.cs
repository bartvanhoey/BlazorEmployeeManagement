using EmployeeManagement.Client.Pages.CustomDataSorting;
using EmployeeManagement.Client.Pages.ServerPaging;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA0NzQ1MUAzMjM0MmUzMDJlMzBGTmhPTFc1S3h0WnNwb1ZMaTFqVXNLcHR5TXd2ZXpHVkJCZ3FYR0Q3T0hRPQ==");  
            
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

            builder.Services.AddScoped<DataGridServerPagingDataAdaptor>();
            builder.Services.AddScoped<CustomDataSortingDataAdaptor>();

            await builder.Build().RunAsync();
        }
    }
}