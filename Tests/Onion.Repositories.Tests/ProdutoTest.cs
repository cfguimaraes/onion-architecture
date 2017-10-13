using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onion.Repositories.Contracts;
using Onion.Repositories.Tests.Implementations;

namespace Onion.Repositories.Tests
{
    [TestClass]
    public class ProdutoTest
    {
        IProdutoRepository _produtoRepository;

        public ProdutoTest() => _produtoRepository = new ProdutoRepositoryStub();

        [TestMethod]
        public void DeveDetalharUmProdutoQualquer()
        {
            // Arrange
            Guid produtoID = Guid.NewGuid();

            // Act
            var produto = _produtoRepository.Detalhar(produtoID);

            //Assert
            Assert.IsNotNull(produto);
            Assert.AreEqual(produtoID, produto.Id);
            Assert.AreEqual("Teste", produto.Descricao);
            Assert.AreEqual("A", produto.IdentificadorVisual);
            Assert.AreEqual(14m, produto.Valor);
        }
    }
}
