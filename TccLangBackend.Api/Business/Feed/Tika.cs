using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TccLangBackend.Api.Business.Feed
{
    public class Tika
    {
        private readonly string _url;

        public Tika(string url) => _url = url;

        public Task<string> GetMainTextAsync()
        {
            var location = Assembly.GetEntryAssembly()?.Location;
            var fullPath = Path.GetDirectoryName(location);

            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = $"-jar {fullPath}/tika-app-1.22.jar --text-main {_url}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            })
            {
                process.Start();
                process.WaitForExit();
                return process.StandardOutput.ReadToEndAsync();
            }
        }
    }
}