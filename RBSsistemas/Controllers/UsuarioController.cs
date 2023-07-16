using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RBSsistemas.Models;
using RBSsistemas.Repositories.Interfaces;

namespace RBSsistemas.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorie _usuarioRepositorie;

        public UsuarioController(IUsuarioRepositorie usuarioRepositorie)
        {
            _usuarioRepositorie = usuarioRepositorie;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorie.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("search/{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            UsuarioModel usuarios = await _usuarioRepositorie.BucarPorId(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorie.Adicionar(usuarioModel);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;

            if (usuarioModel.Email != "" && usuarioModel.Nome != "")
            {
                UsuarioModel usuario = await _usuarioRepositorie.Atualizar(usuarioModel, id);
                return Ok(usuario);
            }

            return BadRequest(usuarioModel.Nome == "" ? "Campo Nome nulo" : "Campo Email nulo");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorie.Apagar(id);

            return Ok(apagado);
        }
    }
}
