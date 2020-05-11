using System.IO;
using System.Threading.Tasks;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreRazzleExample.Services
{
    public interface IRenderService
    {
        Task<string> RenderAsync(string url);
    }

    public class RenderService : IRenderService
    {
        private readonly INodeJSService _nodeJSService;
        private readonly string _renderJsPath;

        public RenderService(INodeJSService nodeJSService, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment is null) throw new System.ArgumentNullException(nameof(webHostEnvironment));
            _nodeJSService = nodeJSService ?? throw new System.ArgumentNullException(nameof(nodeJSService));
            _renderJsPath = webHostEnvironment.ContentRootFileProvider.GetFileInfo("./ClientApp/build/server.js").PhysicalPath;
        }
        public Task<string> RenderAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new System.ArgumentException($"{nameof(url)} must not be null or empty", nameof(url));

            return _nodeJSService.InvokeFromFileAsync<string>(_renderJsPath, args: new object[] { url });
        }
    }
}