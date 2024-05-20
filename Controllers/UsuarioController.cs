using CadastroContatos.Filters;
using CadastroContatos.Models;
using CadastroContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Usuário deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops! Falha ao deletar o usuário. Detalhes do error: {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops! Falha ao cadastrar o usuario. Detalhes do error: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);
            }
            catch (Exception error)
            {
                TempData["MensagemError"] = $"Ops! Não conseguimos alterar o usuário. Detalhes do error: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
