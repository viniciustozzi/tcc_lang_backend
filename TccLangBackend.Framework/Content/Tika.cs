using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TccLangBackend.Framework.Content
{
    public class Tika
    {
        public static Task<string> GetMainTextAsync(string url)
        {
            var location = Assembly.GetEntryAssembly()?.Location;
            var fullPath = Path.GetDirectoryName(location);
            var escapeUriString = Uri.EscapeUriString(url);
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "java",
                    Arguments = $"-jar {fullPath}/tika-app-1.22.jar --text-main {escapeUriString}",
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