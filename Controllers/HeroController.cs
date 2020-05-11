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
    public class HeroController : Controller
    {
        private readonly ILogger<HeroController> _logger;
        private readonly IRenderService _renderService;

        public HeroController(ILogger<HeroController> logger, IRenderService renderService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _renderService = renderService ?? throw new ArgumentNullException(nameof(renderService));
        }

        [Route("/")]
        public IActionResult Index()
        {
            return new SsrResult("/");
        }

        [Route("/{id:int}")]
        public IActionResult Detail(int id)
        {
            return new SsrResult("/:id");
        }
    }
}
