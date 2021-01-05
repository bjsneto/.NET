using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Domain;
using Repository.Contracts;
using Service.Contracts;

namespace Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(Pessoa pessoa)
        {
            await _repository.Create(pessoa);
        }

        public async Task Update(Pessoa pessoa)
        {
            await _repository.Update(pessoa);
        }

        public async Task<Pessoa> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
