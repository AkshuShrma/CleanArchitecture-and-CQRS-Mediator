using Application.Common.Interfaces;
using Castle.Core.Logging;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NSubstituteQueryingDBContext
{
    public class TestScheduleTransport : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public TestScheduleTransport(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void GetAllScheduleTransport()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var scheduleTransportRepo = scope.ServiceProvider.GetService<IScheduleTransportRepository>();

            if (scheduleTransportRepo == null)
                throw new Exception("scheduleTransportRepo is null in Test");

            // Act
            var response = scheduleTransportRepo.GetScheduleTransports();


            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var scheduleTransportRepo = scope.ServiceProvider.GetService<IScheduleTransportRepository>();

            if (scheduleTransportRepo == null)
                throw new Exception("scheduleTransportRepo is null in Test");

            // Replace 'scheduleTransportId' with the ID of the scheduleTransport you want to retrieve.
            var scheduleTransportId = 1; // Replace with your specific scheduleTransport's ID.

            // Act
            var response = await scheduleTransportRepo.GetScheduleTransportById(scheduleTransportId);


            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task AddScheduleTransport()
        {
            // Arrange
            var scheduleTransport = new ScheduleTransport
            {
                DateScheduled = DateTime.UtcNow,
                Transporter = "test Name",
                InstructionId = 8,
                ProductId = 4
            };

            using var scope = _factory.Services.CreateScope();
            var scheduleTransportRepo = scope.ServiceProvider.GetService<IScheduleTransportRepository>();

            if (scheduleTransportRepo == null)
                throw new Exception("scheduleTransportRepo is null in Test");

            // Act
            var response = await scheduleTransportRepo.AddScheduleTransport(scheduleTransport);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(scheduleTransport, response);
        }

        [Fact]
        public async Task UpdateScheduleTransport()
        {
            // Arrange
            var scheduleTransport = new ScheduleTransport
            {
                ScheduleTransportID = 1,
                DateScheduled = DateTime.UtcNow,
                Transporter = "test Name u",
                InstructionId = 8,
                ProductId = 4
            };

            using var scope = _factory.Services.CreateScope();
            var scheduleTransportRepo = scope.ServiceProvider.GetService<IScheduleTransportRepository>();

            if (scheduleTransportRepo == null)
                throw new Exception("scheduleTransportRepo is null in Test");

            // Act
            var response = await scheduleTransportRepo.AddScheduleTransport(scheduleTransport);




            // Assert
            Assert.NotNull(response);
            Assert.Equal(scheduleTransport, response);
        }
    }
}
