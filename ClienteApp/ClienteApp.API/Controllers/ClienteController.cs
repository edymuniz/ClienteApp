using ClienteApp.Application.Cliente.Commands.Interface;
using ClienteApp.Application.Cliente.Queries.Interface;
using ClienteApp.Domain.Cliente.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClienteApp.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    public class ClienteController : BaseController
    {

        private readonly IGetClienteQuery _getClienteApplication;
        private readonly ICreateClienteCommand _createClienteApplication;
        private readonly IUpdateClienteCommand _updateClienteApplication;
        private readonly IDeleteClienteCommand _deleteClienteApplication;

        public ClienteController(IGetClienteQuery getClienteApplication, ICreateClienteCommand createClienteApplication,
                                    IUpdateClienteCommand updateClienteApplication, IDeleteClienteCommand deleteClienteApplication)
        {
            _getClienteApplication = getClienteApplication;
            _createClienteApplication = createClienteApplication;
            _updateClienteApplication = updateClienteApplication;
            _deleteClienteApplication = deleteClienteApplication;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar cliente")]
        public async Task<IActionResult> Create([FromBody] ClienteRequest clienteRequest)
        {
            var result = await _createClienteApplication.SalvarClienteAsync(clienteRequest);
            return CustomResponse(result.Id, result, "Cliente cadastrado com sucesso.");            
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Consultar todos os clientes")]
        public async Task<IActionResult> GetAll()
        {
             return CustomResponse(0, await _getClienteApplication.GetAllAsync());
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar cliente")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteRequest clienteRequest)
        {
            return CustomResponse(id, await _updateClienteApplication.AlterarClienteAsync(id, clienteRequest));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar cliente pelo ID.")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return CustomResponse(id, await _getClienteApplication.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover Cliente pelo ID")]
        public async Task<IActionResult> Delete(int id)
        {
            return CustomResponse(id, await _deleteClienteApplication.ApagarClienteAsync(id));            
        }
    }
}