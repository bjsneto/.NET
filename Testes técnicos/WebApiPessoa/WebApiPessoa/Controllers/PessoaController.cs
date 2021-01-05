using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using WebApiPessoa.Dtos;

namespace WebApiPessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet, Route("BuscarPessoa")]
        public async Task<PessoaDto> BuscarPessoa(Guid id)
        {
            var pessoa = _mapper.Map<PessoaDto>(await _service.GetById(id));
            return pessoa;
        }

        [HttpPost, Route("CriarPessoa")]
        public async Task CriarPessoa(PessoaDto pessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDto);
            await _service.Create(pessoa);
        }

        [HttpPost, Route("AtualizarPessoa")]
        public async Task AtualizarPessoa(PessoaDto pessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDto);
            await _service.Update(pessoa);
        }

        [HttpPost, Route("ExcluirPessoa")]
        public async Task ExcluirPessoa(Guid id)
        {
            await _service.Delete(id);
        }

        [HttpGet, Route("BuscarTodasPessoas")]
        public async Task<IEnumerable<PessoaDto>> BuscarTodasPessoas()
        {
            var pessoas = await _service.GetAll();
            return _mapper.Map<IEnumerable<PessoaDto>>(pessoas);
        }
    }
}
