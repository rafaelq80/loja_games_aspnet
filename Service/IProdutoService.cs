﻿using loja_games.Model;

namespace loja_games.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task <IEnumerable<Produto>> GetByNomeELaboratorio(string nome, string console);

        Task<IEnumerable<Produto>> GetByNomeOuLaboratorio(string nome, string console);

        Task<IEnumerable<Produto>> GetByBetweenPreco(decimal precoInicial, decimal precoFinal);

        Task<IEnumerable<Produto>> GetByBetweenDataLancamento(DateTime dataInicial, DateTime dataFinal);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);

        Task<Produto?> Curtir(long id);
    }
}
