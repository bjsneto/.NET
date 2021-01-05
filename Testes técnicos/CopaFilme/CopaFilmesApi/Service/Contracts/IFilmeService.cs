using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Domain;

namespace Service.Contracts
{
    public interface IFilmeService
    {
        Task<List<Filme>> ObterTodos();
        Task<List<Filme>> GerarCompeticao(List<Filme> filmes);
        Task<List<Filme>> FazerFinal(List<Filme> filmes);
    }
}
