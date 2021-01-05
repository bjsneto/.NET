using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CopaFilmesApi.Dto;
using Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CopaFilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CopaFilmeController : ControllerBase
    {
        private readonly IFilmeService _service;
        private readonly IMapper _mapper;
        public CopaFilmeController(IFilmeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet, Route("ObterTodos")]
        public async Task<List<FilmesDto>> ObterTodos()
        {
            return _mapper.Map<List<FilmesDto>>(await _service.ObterTodos());
        }

        [HttpPost, Route("FazerCompeticao")]
        public async Task<List<FilmesDto>> FazerCompeticao([FromBody] List<FilmesDto> filmes)
        {
            var vencedores = _mapper.Map<List<FilmesDto>>(await _service.GerarCompeticao(_mapper.Map<List<Filme>>(filmes.OrderBy(x => x.Titulo))));
            var finalista = _mapper.Map<List<FilmesDto>>(await _service.GerarCompeticao(_mapper.Map<List<Filme>>(vencedores)));

            var retorno = _mapper.Map<List<FilmesDto>>(await _service.FazerFinal(_mapper.Map<List<Filme>>(finalista)));
            return retorno;
        }
    }
}
