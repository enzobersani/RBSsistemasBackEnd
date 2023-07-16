using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBSsistemas.Models;
using RBSsistemas.Repositories.Interfaces;

namespace RBSsistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepositorie _fornecedorRepositorie;

        public FornecedorController(IFornecedorRepositorie fornecedorRepositorie)
        {
            _fornecedorRepositorie = fornecedorRepositorie;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<FornecedorModel>>> BuscarTodosFornecedores()
        {
            List<FornecedorModel> fornecedor = await _fornecedorRepositorie.BuscarTodosFornecedores();
            return Ok(fornecedor);
        }

        [HttpGet("search/{id}")]
        public async Task<ActionResult<List<FornecedorModel>>> BuscarPorId(int id)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorie.BucarPorId(id);
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorModel>> Cadastrar([FromBody] FornecedorModel fornecedorModel)
        {
            FornecedorModel fornecedor = await _fornecedorRepositorie.Adicionar(fornecedorModel);

            return Ok(fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FornecedorModel>> Atualizar([FromBody] FornecedorModel fornecedorModel, int id)
        {
            fornecedorModel.Id = id;

            if (fornecedorModel.Email != "" && fornecedorModel.NomeFantasia != "")
            {
                FornecedorModel fornecedor = await _fornecedorRepositorie.Atualizar(fornecedorModel, id);
                return Ok(fornecedor);
            }

            return BadRequest(fornecedorModel.NomeFantasia == "" ? "Campo Nome nulo" : "Campo Email nulo");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FornecedorModel>> Apagar(int id)
        {
            bool apagado = await _fornecedorRepositorie.Apagar(id);

            return Ok($"Fornecedor {id} apagado!");
        }
    }
}
