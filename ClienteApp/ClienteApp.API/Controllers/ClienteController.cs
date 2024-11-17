using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Application.Cliente.Queries.Interface;
using ClienteApp.Domain.Cliente.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClienteApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly IGetClienteService _getClienteApplication;
        private readonly ICreateClienteService _createClienteApplication;
        private readonly IUpdateClienteService _updateClienteApplication;
        private readonly IDeleteClienteService _deleteClienteApplication;

        public ClienteController(IGetClienteService getClienteApplication, ICreateClienteService createClienteApplication,
                                    IUpdateClienteService updateClienteApplication, IDeleteClienteService deleteClienteApplication)
        {
            _getClienteApplication = getClienteApplication;
            _createClienteApplication = createClienteApplication;
            _updateClienteApplication = updateClienteApplication;
            _deleteClienteApplication = deleteClienteApplication;
        }

        [SwaggerOperation(Summary = "Cadastrar cliente")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteRequest clienteRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _createClienteApplication.SalvarClienteAsync(clienteRequest);
            if (result == null)
            {
                return BadRequest("Não foi possível cadastrar o cliente!");
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Consultar todos os clientes")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getClienteApplication.GetAllAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                await _updateClienteApplication.AlterarClienteAsync(id, clienteRequest);
                return Ok(new { message = "Cliente atualizado com sucesso." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                 return StatusCode(500, @"Erro ao atualizar o cliente: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar cliente pelo ID.")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _getClienteApplication.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [SwaggerOperation(Summary = "Remover Cliente pelo ID")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deleteClienteApplication.ApagarClienteAsync(id);

            if (result == "Cliente não encontrada.")
            {
                return NotFound(new { message = result });
            }

            if (result.StartsWith("Erro ao remover o cliente"))
            {
                return StatusCode(500, new { message = result });
            }

            return Ok(new { message = result });
        }
    }
}
