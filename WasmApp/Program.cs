using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorAnimation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace WasmApp
{
    public class Program {
		public static async Task Main(string[] args) {
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.Configure<AnimationOptions>(Guid.NewGuid().ToString(),c=>{});

			await builder.Build().RunAsync();
		}
	}
}
