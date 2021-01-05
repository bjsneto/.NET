
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Domain;

namespace Repository.Contracts
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> ObterTodos();
    }
}
