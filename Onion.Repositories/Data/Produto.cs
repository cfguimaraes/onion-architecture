using System;

namespace Onion.Repositories.Data
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string IdentificadorVisual { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}