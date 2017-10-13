using System;
using Onion.Repositories.Data;

namespace Onion.Repositories.Contracts
{
    public interface IProdutoRepository
    {
         Produto Detalhar(Guid produtoID);
    }
}