using CadastroContatos.Data;
using CadastroContatos.Models;

namespace CadastroContatos.Repositorio;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly BancoContext _context;

    public UsuarioRepositorio(BancoContext context)
    {
        _context = context;
    }

    public UsuarioModel Adicionar(UsuarioModel usuario)
    {
        usuario.DataCadastro = DateTime.Now;
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public bool Apagar(int id)
    {
        UsuarioModel usuarioDb = ListarPorId(id);
        if (usuarioDb == null) throw new Exception("Houve um error na deleção do contato");
        _context.Usuarios.Remove(usuarioDb);
        _context.SaveChanges();
        return true;
    }

    public UsuarioModel Atualizar(UsuarioModel usuario)
    {
        UsuarioModel usuarioDb = ListarPorId(usuario.Id);

        if (usuarioDb == null) throw new Exception("Houve um error na atualização do usuario");

        usuarioDb.Nome = usuario.Nome;
        usuarioDb.Email = usuario.Email;
        usuarioDb.Login = usuario.Login;
        usuarioDb.Perfil = usuario.Perfil;
        usuarioDb.DataAtualizacao = DateTime.Now;

        _context.Usuarios.Update(usuarioDb);
        _context.SaveChanges();
        
        return usuarioDb;
    }

    public List<UsuarioModel> BuscarTodos()
    {
        return _context.Usuarios.ToList();
    }

    public UsuarioModel ListarPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Id == id);
    }
}
