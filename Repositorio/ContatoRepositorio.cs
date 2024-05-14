using CadastroContatos.Data;
using CadastroContatos.Models;

namespace CadastroContatos.Repositorio;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly BancoContext _context;

    public ContatoRepositorio(BancoContext context)
    {
        _context = context;
    }

    public ContatoModel Adicionar(ContatoModel contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
        return contato;
    }

    public bool Apagar(int id)
    {
        ContatoModel contatoDb = ListarPorId(id);
        if (contatoDb == null) throw new Exception("Houve um error na deleção do contato");
        _context.Contatos.Remove(contatoDb);
        _context.SaveChanges();
        return true;
    }

    public ContatoModel Atualizar(ContatoModel contato)
    {
        ContatoModel contatoDb = ListarPorId(contato.Id);
        if (contatoDb == null) throw new Exception("Houve um error na atualização do contato");
        contatoDb.Nome = contato.Nome;
        contatoDb.Email = contato.Email;
        contatoDb.Celular = contato.Celular;
        _context.Contatos.Update(contatoDb);
        _context.SaveChanges();
        return contatoDb;
    }

    public List<ContatoModel> BuscarTodos()
    {
        return _context.Contatos.ToList();
    }

    public ContatoModel ListarPorId(int id)
    {
        return _context.Contatos.FirstOrDefault(x => x.Id == id);
    }
}
