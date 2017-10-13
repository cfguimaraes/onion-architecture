using Onion.Dtos.Requests;
using Onion.Dtos.Responses.Produtos.ECommerce;
using Onion.Repositories.Contracts;

namespace Onion.UseCases.Produtos
{
    public class Produto
    {
        private readonly IProdutoRepository _produtoRepository;
        public Produto(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;

        }
        public DetalharProdutoResponse Detalhar(DetalharProdutoRequest request)
        {
            /*Criar mecanismo de validação
              //Fluent Validation
              //DataAnnotations com Component Model
              //Método de validação no request e fazendo chamada
            */
            var produto = _produtoRepository.Detalhar(request.Id);

            
            //Sugestão é acrescentar um automapper ou criar um operator no DTO para deixar o código mais limpo
            return new DetalharProdutoResponse {
                Id = produto.Id,
                Identificador = produto.IdentificadorVisual,
                Valor = produto.Valor,
                Nome = produto.Descricao
            };
        }
    }
}