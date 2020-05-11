using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreRazzleExample.Services
{
    public class SsrResult : IActionResult
    {
        private readonly string _url;
        public SsrResult(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new System.ArgumentException($"{nameof(url)} must not be null or empty", nameof(url));

            _url = url;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            if (context is null) throw new System.ArgumentNullException(nameof(context));

            var renderService = context.HttpContext.RequestServices.GetRequiredService<IRenderService>();
            var renderResult = await renderService.RenderAsync(_url);
            var contentResult = new ContentResult
            {
                Content = renderResult,
                ContentType = "text/html"
            };
            await contentResult.ExecuteResultAsync(context);
        }
    }
}