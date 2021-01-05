using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Domain;
using Moq;
using Repository.Contracts;
using Repository.Reposiroies;
using Service.Services;
using Xunit;

namespace CopaFilmesTests
{
    public class FilmeTests
    {

        [Fact]
        public async Task Deve_Obter_Todos()
        {

            var mochttp = new Mock<HttpClient>();

            var repository = new FilmeRepository(mochttp.Object);

            var result = await repository.ObterTodos();

            Assert.Equal(16, result.Count);
        }

        [Fact]
        public async void Deve_Obter_Selecao()
        {


            var lista = new List<Filme>
            {
              new Filme  {
                    Id="tt3606756",
                    Titulo="Os Incríveis 2",
                    Ano=2018,
                    Nota=8.5f
                },
              new Filme   {
                    Id="tt4881806",
                    Titulo="Jurassic World= Reino Ameaçado",
                    Ano=2018,
                    Nota=6.7f
                },
              new Filme   {
                    Id="tt5164214",
                    Titulo="Oito Mulheres e um Segredo",
                    Ano=2018,
                    Nota=6.3f
                },
              new Filme   {
                    Id="tt7784604",
                    Titulo="Hereditário",
                    Ano=2018,
                    Nota=7.8f
                },
              new Filme   {
                    Id="tt4154756",
                    Titulo="Vingadores= Guerra Infinita",
                    Ano=2018,
                    Nota=8.8f
                },
              new Filme  {
                    Id="tt5463162",
                    Titulo="Deadpool 2",
                    Ano=2018,
                    Nota=8.1f
                },
              new Filme  {
                    Id="tt3778644",
                    Titulo="Han Solo= Uma História Star Wars",
                    Ano=2018,
                    Nota=7.2f
                },
              new Filme    {
                    Id="tt3501632",
                    Titulo="Thor= Ragnarok",
                    Ano=2017,
                    Nota=7.9f
                },
              new Filme   {
                    Id="tt2854926",
                    Titulo="Te Peguei!",
                    Ano=2018,
                    Nota=7.1f
                },
              new Filme   {
                    Id="tt0317705",
                    Titulo="Os Incríveis",
                    Ano=2004,
                    Nota=8.0f
                },
              new Filme   {
                    Id="tt3799232",
                    Titulo="A Barraca do Beijo",
                    Ano=2018,
                    Nota=6.4f
                },
              new Filme   {
                    Id="tt1365519",
                    Titulo="Tomb Raider= A Origem",
                    Ano=2018,
                    Nota=6.5f
                },
              new Filme   {
                    Id="tt1825683",
                    Titulo="Pantera Negra",
                    Ano=2018,
                    Nota=7.5f
                },
              new Filme  {
                    Id="tt5834262",
                    Titulo="Hotel Artemis",
                    Ano=2018,
                    Nota=6.3f
                },
              new Filme   {
                    Id="tt7690670",
                    Titulo="Superfly",
                    Ano=2018,
                    Nota=5.1f
                },
              new Filme   {
                    Id="tt6499752",
                    Titulo="Upgrade",
                    Ano=2018,
                    Nota=7.8f
                }
            };


            var mocRepository = new Mock<IFilmeRepository>();

            var service = new FilmeService(mocRepository.Object);
            var result = await service.GerarCompeticao(lista);
            Assert.Equal(8, result.Count);

        }
        [Fact]
        public async Task Deve_Obter_Fase_Eliminatoria()
        {

            var lista = new List<Filme>
            {
              new Filme  {
                    Id="tt3606756",
                    Titulo="Os Incríveis 2",
                    Ano=2018,
                    Nota=8.5f
                },
              new Filme   {
                    Id="tt4881806",
                    Titulo="Jurassic World= Reino Ameaçado",
                    Ano=2018,
                    Nota=6.7f
                },
              new Filme   {
                    Id="tt5164214",
                    Titulo="Oito Mulheres e um Segredo",
                    Ano=2018,
                    Nota=6.3f
                },
              new Filme   {
                    Id="tt7784604",
                    Titulo="Hereditário",
                    Ano=2018,
                    Nota=7.8f
                },
              new Filme   {
                    Id="tt4154756",
                    Titulo="Vingadores= Guerra Infinita",
                    Ano=2018,
                    Nota=8.8f
                },
              new Filme  {
                    Id="tt5463162",
                    Titulo="Deadpool 2",
                    Ano=2018,
                    Nota=8.1f
                },
              new Filme  {
                    Id="tt3778644",
                    Titulo="Han Solo= Uma História Star Wars",
                    Ano=2018,
                    Nota=7.2f
                },
              new Filme    {
                    Id="tt3501632",
                    Titulo="Thor= Ragnarok",
                    Ano=2017,
                    Nota=7.9f
                },
              
            };

            var mocRepository = new Mock<IFilmeRepository>();

            var service = new FilmeService(mocRepository.Object);
            var result = await service.GerarCompeticao(lista);

            Assert.Equal(4, result.Count);
        }

        [Fact]
        public async Task Deve_Obter_Finalistas()
        {
            var lista = new List<Filme>
            {
                new Filme  {
                    Id="tt3606756",
                    Titulo="Os Incríveis 2",
                    Ano=2018,
                    Nota=8.5f
                },
                new Filme   {
                    Id="tt4881806",
                    Titulo="Jurassic World= Reino Ameaçado",
                    Ano=2018,
                    Nota=6.7f
                },
                new Filme   {
                    Id="tt5164214",
                    Titulo="Oito Mulheres e um Segredo",
                    Ano=2018,
                    Nota=6.3f
                },
                new Filme   {
                    Id="tt7784604",
                    Titulo="Hereditário",
                    Ano=2018,
                    Nota=7.8f
                }

            };

            var mocRepository = new Mock<IFilmeRepository>();

            var service = new FilmeService(mocRepository.Object);
            var result = await service.GerarCompeticao(lista);

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Deve_Obter_Campeao_Notas_Iguais()
        {

            var lista = new List<Filme>
            {
                new Filme  {
                    Id="tt3606756",
                    Titulo="Os Incríveis 2",
                    Ano=2018,
                    Nota=8.5f
                },
                new Filme   {
                    Id="tt4881806",
                    Titulo="Jurassic World= Reino Ameaçado",
                    Ano=2018,
                    Nota=8.5f
                },
               

            };

            var mocRepository = new Mock<IFilmeRepository>();
           
            var service = new FilmeService(mocRepository.Object);

            var result = await service.FazerFinal(lista);

            Assert.True(result.First().Nota.Equals(result[^1].Nota));

        }
        [Fact]
        public async Task Deve_Obter_Campeao_Notas_Diferentes()
        {

            var lista = new List<Filme>
            {
                new Filme  {
                    Id="tt3606756",
                    Titulo="Os Incríveis 2",
                    Ano=2018,
                    Nota=8.5f
                },
                new Filme   {
                    Id="tt4881806",
                    Titulo="Jurassic World= Reino Ameaçado",
                    Ano=2018,
                    Nota=6.5f
                },


            };

            var mocRepository = new Mock<IFilmeRepository>();

            var service = new FilmeService(mocRepository.Object);

            var result = await service.FazerFinal(lista);

            Assert.True(result.First().Nota > result[^1].Nota);


        }

    }
}

