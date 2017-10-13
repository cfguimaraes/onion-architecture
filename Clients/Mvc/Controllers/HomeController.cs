using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Onion.Dtos.Requests;
using Onion.Dtos.Responses.Produtos.ECommerce;
using Onion.Repositories.Contracts;
using Onion.UseCases.Produtos;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider serviceProvider;
        public HomeController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("produto")]
        public IActionResult Produto()
        {
            IProdutoRepository produtoRepository = serviceProvider.GetService(typeof(IProdutoRepository)) as IProdutoRepository;
            DetalharProdutoResponse produtoResponse = new Produto(produtoRepository).Detalhar(new DetalharProdutoRequest { Id = Guid.NewGuid() });
            return base.Ok(produtoResponse);
        }

    }
}
