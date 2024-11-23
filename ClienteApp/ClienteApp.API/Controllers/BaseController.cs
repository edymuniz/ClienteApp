using ClienteApp.Domain.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClienteApp.API.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        protected IActionResult CustomResponse(int id, object data = null, string msgAlternativa = null)
        {
            try
            {
                if (data == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Message = $"Cliente com ID {id} não encontrado no banco de dados."
                    });
                }

                if (data is string message && message.StartsWith("Erro "))
                {
                    return BadRequest(new ApiResponse<string>
                    {
                        Success = false,
                        Message = message
                    });
                }

                if (data is string)
                {
                    return Ok(new ApiResponse<string>
                    {
                        Success = true,
                        Message = (string)data
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = msgAlternativa,
                    Data = data
                });                

            }
            catch (Exception ex)
            {
                string errors = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = errors
                });
            }
        }
    }
}
