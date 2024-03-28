using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Moq;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class ContatoServiceTest
    {
        [Fact]
        [Benchmark]
        public void ContatoServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var contatoRepoMock = new Mock<IContatoRepository>();

            var contatoService = new ContatoService(mapperMock.Object, contatoRepoMock.Object);

            // Act
            var contatos = contatoService.GetAllAsync();

            // Assert
            Assert.NotNull(contatos);

            contatos.ShouldNotBeNull();

            contatoRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}