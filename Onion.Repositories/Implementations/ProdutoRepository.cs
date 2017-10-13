using System;
using Onion.Repositories.Contracts;
using Onion.Repositories.Data;

namespace Onion.Repositories.Implementations
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Produto Detalhar(Guid produtoID)
        {
            return new Produto(){
                Descricao = "Produto de demonstração",
                Id = Guid.NewGuid(),
                IdentificadorVisual = "A",
                Valor = 25m
            };
        }
    }
}