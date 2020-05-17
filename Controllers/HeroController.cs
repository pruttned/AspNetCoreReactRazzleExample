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
        private IHeroDb _db;

        public HeroController(IHeroDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [Route("/")]
        public IActionResult Index() => new SsrResult("/");

        [Route("data/")]
        public IActionResult IndexData() => Ok(_db.GetAll());

        [Route("/{id:int}")]
        public IActionResult Detail(int id) => new SsrResult("/:id");

        [Route("/data/{id:int}")]
        public IActionResult DetailData(int id) => Ok(_db.Get(id));
    }
}
