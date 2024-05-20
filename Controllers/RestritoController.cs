using CadastroContatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
