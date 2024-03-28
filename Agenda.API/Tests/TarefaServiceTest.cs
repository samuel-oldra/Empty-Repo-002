using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Moq;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class TarefaServiceTest
    {
        [Fact]
        [Benchmark]
        public void TarefaServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var tarefaRepoMock = new Mock<ITarefaRepository>();

            var tarefaService = new TarefaService(mapperMock.Object, tarefaRepoMock.Object);

            // Act
            var tarefas = tarefaService.GetAllAsync();

            // Assert
            Assert.NotNull(tarefas);

            tarefas.ShouldNotBeNull();

            tarefaRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}