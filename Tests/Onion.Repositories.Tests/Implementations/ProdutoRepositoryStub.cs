using System;
using Onion.Repositories.Contracts;
using Onion.Repositories.Data;

namespace Onion.Repositories.Tests.Implementations
{
    public class ProdutoRepositoryStub : IProdutoRepository
    {
        public Produto Detalhar(Guid produtoID)
        {
            return new Produto()
            {
                Id = produtoID,
                Descricao = "Teste",
                IdentificadorVisual = "A",
                Valor = 14m
            };
        }
    }
}