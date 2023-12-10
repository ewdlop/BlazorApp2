using Google.Apis.Services;
using System;
using System.Threading.Tasks;



namespace BlazorApp2.Components.Pages;

public partial class Home
{
    protected override void OnAfterRender(bool firstRender)
    {
        if(firstRender)
        {
            // Create the service.
            var service = new DiscoveryService(new BaseClientService.Initializer
            {
                ApplicationName = "Discovery Sample",
                ApiKey = "[YOUR_API_KEY_HERE]",
            });

            // Run the request.
            Console.WriteLine("Executing a list request...");
            var result = await service.Apis.List().ExecuteAsync();

            // Display the results.
            if (result.Items != null)
            {
                foreach (DirectoryList.ItemsData api in result.Items)
                {
                    Console.WriteLine(api.Id + " - " + api.Title);
                }
            }
            Console.WriteLine("First render");
        }
        else
        {
            Console.WriteLine("Not first render");
        }
        base.OnAfterRender(firstRender);
    }
}