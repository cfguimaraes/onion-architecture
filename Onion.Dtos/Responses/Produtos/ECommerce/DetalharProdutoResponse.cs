using System;

namespace Onion.Dtos.Responses.Produtos.ECommerce
{
    public class DetalharProdutoResponse
    {
        public Guid Id { get; set; }
        public string Identificador { get; set; }
        public decimal Valor { get; set; }
        public string Nome { get; set; }

    }
}