using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Validations.Client;
using Validations.Client.IRepository;
using Validations.Client.Repository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:19021/") });
builder.Services.AddScoped<IPeselHttpRepository, PeselHttpRepository>();
builder.Services.AddScoped<INipHttpRepository, NipHttpRepository>();

await builder.Build().RunAsync();

