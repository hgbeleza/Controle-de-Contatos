using CadastroContatos.Models;

namespace CadastroContatos.Repositorio;

public interface IUsuarioRepositorio
{
    List<UsuarioModel> BuscarTodos();
    UsuarioModel Adicionar(UsuarioModel contato);
    UsuarioModel ListarPorId(int id);
    UsuarioModel Atualizar(UsuarioModel contato);
    bool Apagar(int id);
}
