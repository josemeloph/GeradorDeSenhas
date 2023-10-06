using GeradorDeSenhas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeSenhas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Senha senha)
        {
            return View(senha);
        }

        [HttpPost]
        public IActionResult GerarSenha(Senha senha)
        {
            string caracteres = senha.CaracteresPossiveis();
            Random sorteio = new Random();
            int numeroSorteado = 0;
            StringBuilder senhaGerada = new StringBuilder();

            if (caracteres.Length > 0)
            {
                for (int i = 0; i < senha.Tamanho; i++)
                {
                    numeroSorteado = sorteio.Next(0, caracteres.Length - 1);
                    senhaGerada.Append(caracteres[numeroSorteado]);
                }
            }
            senha.Valor = senhaGerada.ToString();
            return RedirectToAction("Index", senha);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
