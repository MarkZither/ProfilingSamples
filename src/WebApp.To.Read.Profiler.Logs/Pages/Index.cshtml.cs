using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using StackExchange.Profiling;

namespace WebApp.To.Read.Profiler.Logs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var url = "https://www.dennemeyer.com";
            using (MiniProfiler.Current.Step("GetIndex"))
            {
                var client = new WebClient();
                var reply = client.DownloadString(url);
            }
        }
    }
}
