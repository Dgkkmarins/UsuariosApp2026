using ClientesApp.API.Dtos;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Enums;
using ClientesApp.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ClienteRequestDto dto)
        {
            try
            {
                //Capturar os dados do dto
                var cliente = new Cliente()
                {
                    Nome = dto.Nome!,
                    Cpf = dto.Cpf!,
                    Email = dto.Email!,
                    Telefone = dto.Telefone!,
                    Nivel = (NivelCliente)dto.Nivel!
                };

                //Salvar no banco de dados
                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                //HTTP 201 - CREATED
                return StatusCode(201, new
                {
                    Message = "Cliente cadastrado com sucesso.",
                    Id = cliente.Id,
                    Data = dto
                });
            }
            catch (ApplicationException e)
            {
                //HTTP 422 - UNPROCESSABLE CONTENT
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
