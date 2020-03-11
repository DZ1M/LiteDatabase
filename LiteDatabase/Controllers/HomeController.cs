using LiteDatabase.Models;
using LiteDatabase.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace LiteDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new DataBase().Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario user)
        {
            new DataBase().Inserir(user);
            TempData["Msg"] =  user.Nome + " foi cadastrado com sucesso!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(Usuario user)
        {
            new DataBase().Alterar(user);
            TempData["Msg"] = user.Nome + " foi alterado com sucesso!";
            return RedirectToAction("Index");
        }
        public IActionResult Excluir(Guid id)
        {
            var busca = new DataBase().BuscaPorId(id);
            new DataBase().Excluir(id);
            TempData["Msg"] = busca.Nome + " foi excluído com sucesso!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Alterar(Guid id)
        {
            return View(new DataBase().BuscaPorId(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
