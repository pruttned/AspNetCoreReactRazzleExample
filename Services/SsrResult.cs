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
            _url = url;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
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