using RBSsistemas.Models;

namespace RBSsistemas.Repositories.Interfaces
{
    public interface IFornecedorRepositorie
    {
        Task<List<FornecedorModel>> BuscarTodosFornecedores();
        Task<FornecedorModel> BucarPorId(int id);
        Task<FornecedorModel> Adicionar(FornecedorModel fornecedor);
        Task<FornecedorModel> Atualizar(FornecedorModel fornecedor, int id);
        Task<bool> Apagar(int id);
    }
}
