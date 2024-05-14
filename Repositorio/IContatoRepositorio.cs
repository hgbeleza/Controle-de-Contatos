using CadastroContatos.Models;

namespace CadastroContatos.Repositorio;

public interface IContatoRepositorio
{
    List<ContatoModel> BuscarTodos();
    ContatoModel Adicionar(ContatoModel contato);
    ContatoModel ListarPorId(int id);
    ContatoModel Atualizar(ContatoModel contato);
    bool Apagar(int id);
}
