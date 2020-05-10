using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AspNetCoreRazzleExample.Services;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
namespace RazorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRenderService _renderService;

        public HomeController(ILogger<HomeController> logger, IRenderService renderService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _renderService = renderService ?? throw new ArgumentNullException(nameof(renderService));
        }

        public IActionResult Index()
        {
            return new SsrResult("/");
        }
    }
}
