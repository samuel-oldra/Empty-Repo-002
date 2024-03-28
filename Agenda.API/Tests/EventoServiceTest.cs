using Agenda.API.Repositories.Interfaces;
using Agenda.API.Services;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Moq;
using Shouldly;
using Xunit;

namespace Agenda.API.Tests
{
    public class EventoServiceTest
    {
        [Fact]
        [Benchmark]
        public void EventoServiceTest_GetAllAsync()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var eventoRepoMock = new Mock<IEventoRepository>();

            var eventoService = new EventoService(mapperMock.Object, eventoRepoMock.Object);

            // Act
            var eventos = eventoService.GetAllAsync();

            // Assert
            Assert.NotNull(eventos);

            eventos.ShouldNotBeNull();

            eventoRepoMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}