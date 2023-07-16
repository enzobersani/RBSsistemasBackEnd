using Microsoft.EntityFrameworkCore;
using RBSsistemas.Data;
using RBSsistemas.Models;
using RBSsistemas.Repositories.Interfaces;

namespace RBSsistemas.Repositories
{
    public class FornecedorRepositorie : IFornecedorRepositorie
    {
        private readonly RBSsistemasDBcontext _dbcontext;
        public FornecedorRepositorie(RBSsistemasDBcontext rbsSistemasDBcontext)
        {
            _dbcontext = rbsSistemasDBcontext;
        }

        public async Task<FornecedorModel> BucarPorId(int id)
        {
            return await _dbcontext.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FornecedorModel>> BuscarTodosFornecedores()
        {
            return await _dbcontext.Fornecedor.ToListAsync();
        }

        public async Task<FornecedorModel> Adicionar(FornecedorModel fornecedor)
        {
            await _dbcontext.Fornecedor.AddAsync(fornecedor);
            await _dbcontext.SaveChangesAsync();

            return fornecedor;
        }

        public async Task<bool> Apagar(int id)
        {
            FornecedorModel fornecedorPorId = await BucarPorId(id);

            if (fornecedorPorId == null)
            {
                throw new Exception($"Usuário com id {fornecedorPorId} não encontrado!");
            }

            _dbcontext.Fornecedor.Remove(fornecedorPorId);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

        public async Task<FornecedorModel> Atualizar(FornecedorModel fornecedor, int id)
        {
            FornecedorModel fornecedorPorId = await BucarPorId(id);

            if (fornecedorPorId == null)
            {
                throw new Exception($"Fornecedor com id {fornecedorPorId} não encontrado!");
            }

            fornecedorPorId.NomeFantasia = fornecedor.NomeFantasia;
            fornecedorPorId.Email = fornecedor.Email;
            fornecedorPorId.CNPJ = fornecedor.CNPJ;
            fornecedorPorId.Telefone = fornecedor.Telefone;

            _dbcontext.Fornecedor.Update(fornecedorPorId);
            await _dbcontext.SaveChangesAsync();

            return fornecedorPorId;
        }
    }
}
