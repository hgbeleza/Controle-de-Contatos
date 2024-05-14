using CadastroContatos.Models;
using CadastroContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContatos.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;

    public ContatoController(IContatoRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio;
    }

    public IActionResult Index()
    {
        List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
        return View(contatos);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult Apagar(int id)
    {
        try
        {
            _contatoRepositorio.Apagar(id);
            TempData["MensagemSucesso"] = "Contato deletado com sucesso!";
            return RedirectToAction("Index");
        }
        catch(Exception error)
        {
            TempData["MensagemError"] = $"Ops! Falha ao deletar o contato. Detalhes do error: {error.Message}";
            return RedirectToAction("Index");
        }
        
    }

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(contato);
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops! Falha ao cadastrar o contato. Detalhes do error: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Alterar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Atualizar(contato);
                TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                return RedirectToAction("Index");
            }
            return View("Editar", contato);
        }
        catch(Exception error)
        {
            TempData["MensagemError"] = $"Ops! Não conseguimos alterar o contato. Detalhes do error: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}
