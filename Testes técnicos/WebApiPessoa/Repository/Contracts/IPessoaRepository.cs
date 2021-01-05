
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Domain;

namespace Repository.Contracts
{
    public interface IPessoaRepository
    {
        Task Create(Pessoa pessoa);
        Task Update(Pessoa pessoa);
        Task<Pessoa> GetById(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}
