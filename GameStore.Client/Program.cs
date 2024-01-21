using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GameStore.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//make calls to the backend  services
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5261") });


//make the resources client server class available for all razor components
//<> - specify the type of class you are registering
//this will signal the API net core runtime - to keep an instance   of the GameClient
builder.Services.AddScoped<GameClient>();
await builder.Build().RunAsync();
