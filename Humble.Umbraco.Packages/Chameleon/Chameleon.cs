using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chameleon
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            using var webpack = new NpmScript();

            await webpack.RunAsync(Console.WriteLine);

            Console.WriteLine(webpack.HasServer
                ? $"From ASP.NET Core. Parcel is started ({webpack.HasServer}) @ {webpack.Url} at process: {webpack.ProcessId}"
                : "Script has executed.");

            await Task.Delay(TimeSpan.FromSeconds(4));
        }
    }
}