using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RBSsistemas.Data;
using RBSsistemas.Models;
using RBSsistemas.Repositories.Interfaces;

namespace RBSsistemas.Repositories
{
    public class UsuarioRepositorie : IUsuarioRepositorie
    {
        private readonly RBSsistemasDBcontext _dbcontext;

        public UsuarioRepositorie(RBSsistemasDBcontext rbsSistemasDBcontext)
        {
            _dbcontext = rbsSistemasDBcontext;
        }
        public async Task<UsuarioModel> BucarPorId(int id)
        {
            return await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbcontext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BucarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com id {usuarioPorId} não encontrado!");
            }
            
            _dbcontext.Usuarios.Remove(usuarioPorId);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BucarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com id {usuarioPorId} não encontrado!");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbcontext.Usuarios.Update(usuarioPorId);
            await _dbcontext.SaveChangesAsync();

            return usuarioPorId;
        }
    }
}
