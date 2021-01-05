using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Domain;
using Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly Context _context;

        public PessoaRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(Pessoa pessoa)
        {
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Pessoa pessoa)
        {
            _context.Entry(await GetById(pessoa.Id)).CurrentValues.SetValues(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<Pessoa> GetById(Guid id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var pessoa = await GetById(id);
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _context.Pessoas.ToListAsync();
        }
    }
}
