using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Repository;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;
        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public IActionResult Cadastrar(CadastrarClienteDTO dto)
        {
            var cliente = new Cliente(dto);
            _repository.Cadastrar(cliente);
            return Ok(cliente);
        }


        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _repository.ObterPorId(id);
            if (cliente is not null)
            {
                var clienteDTO = new ObterClienteDTO(cliente);
                return Ok(clienteDTO);
            }
            else
                return NotFound(new {Mensagem = "Cliente não encontrado!"});
        }
    }
}