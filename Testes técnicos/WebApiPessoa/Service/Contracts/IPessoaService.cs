using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain;

namespace Service.Contracts
{
    public interface IPessoaService
    {
        Task Create(Pessoa pessoa);
        Task Update(Pessoa pessoa);
        Task<Pessoa> GetById(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}
