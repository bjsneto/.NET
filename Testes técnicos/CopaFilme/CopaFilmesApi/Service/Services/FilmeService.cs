
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Repository.Contracts;
using Service.Contracts;

namespace Service.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _repository;

        public FilmeService(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Filme>> ObterTodos()
        {
            var filmes = await _repository.ObterTodos();
            return filmes.OrderBy(x => x.Titulo).ToList();
        }

        public async Task<List<Filme>> GerarCompeticao(List<Filme> filmes)
        {
            var vencedores = new List<Filme>();
            vencedores.AddRange(RetornaGanhadores(filmes));
            return await Task.Run(() => vencedores.ToList());
        }

        public async Task<List<Filme>> FazerFinal(List<Filme> filmes)
        {
            if (filmes.Count % 2 != 0 && filmes.Count != 2)
                return await Task.Run(() => new List<Filme>());

            var primeiro = filmes.First();

            var sesgundo = filmes[^1];

            if (primeiro.Nota == sesgundo.Nota)
            {
                return await Task.Run(() => new List<Filme>() { primeiro, sesgundo }
                    .OrderBy(p => p.Titulo).ToList());

            }
            return await Task.Run(() => new List<Filme>() { primeiro, sesgundo }
                .OrderByDescending(p => p.Nota).ToList());
        }


        private static IEnumerable<Filme> RetornaGanhadores(List<Filme> filmes)
        {
            var vencedores = new List<Filme>();

            while (filmes.Count > 0)
            {
                if (filmes.Count % 2 != 0)
                    return new List<Filme>();

                var primeiro = filmes.First();
                filmes.Remove(primeiro);
                var ultimo = filmes[^1];
                filmes.Remove(ultimo);
                var vencedor = FazerDisputa(primeiro, ultimo);

                vencedores.Add(vencedor);

            }

            return vencedores;
        }
        private static Filme FazerDisputa(Filme primeiroFilme, Filme ultimoFilme)
        {
            if (primeiroFilme.Nota != ultimoFilme.Nota)
                return primeiroFilme.Nota > ultimoFilme.Nota ? primeiroFilme : ultimoFilme;
            var filmes = new List<Filme>() { primeiroFilme, ultimoFilme }
                .OrderBy(p => p.Titulo)
                .First();

            return filmes;

        }
    }
}
