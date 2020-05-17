using System.IO;
using System.Threading.Tasks;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreRazzleExample.Services
{
    public interface IRenderService
    {
        Task<string> RenderAsync(string url, object data);
    }

    public class RenderService : IRenderService
    {
        private static readonly string ServerJsRelPath = "./ClientApp/build/server.js";
        private readonly INodeJSService _nodeJSService;
        private readonly string _serverJsPath;

        public RenderService(INodeJSService nodeJSService, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment is null) throw new System.ArgumentNullException(nameof(webHostEnvironment));
            _nodeJSService = nodeJSService ?? throw new System.ArgumentNullException(nameof(nodeJSService));
            _serverJsPath = webHostEnvironment.ContentRootFileProvider.GetFileInfo(ServerJsRelPath).PhysicalPath;
        }
        public Task<string> RenderAsync(string url, object data)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new System.ArgumentException($"{nameof(url)} must not be null or empty", nameof(url));

            return _nodeJSService.InvokeFromFileAsync<string>(_serverJsPath, args: new object[] { url, data });
        }
    }
}