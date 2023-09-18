
using Application;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;

namespace NSubstituteQueryingDBContext
{
    public class UnitTestInstruction : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UnitTestInstruction(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void GetAllInstructions()
        {
            using var scope = _factory.Services.CreateScope();
            var instructionRepo = scope.ServiceProvider.GetService<IInstructionRepository>();
            if (instructionRepo == null)
            {
                throw new Exception("instructionRepo null in Test");
            }

            var response = instructionRepo.GetInstructions();

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
        }

        [Fact]
        public async Task GetById()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var instructionRepo = scope.ServiceProvider.GetService<IInstructionRepository>();
            if (instructionRepo == null)
            {
                throw new Exception("instructionRepo is null in Test");
            }
            // Replace 'instructionId' with the ID of the instruction you want to retrieve.
            var instructionId = 7; // Replace with your specific instruction ID.

            // Act
            var response = await instructionRepo.GetInstructionById(instructionId);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(instructionId, response.Id); // Assuming 'Id' is the property that represents the instruction's ID.

        }

        [Fact]
        public async Task AddInstruction()
        {
            // Arrange
            var instruction = new Instruction
            {
                InstructionDate = DateTime.UtcNow,
                ClientName = "test Name",
                DeliveryAddress = "test delivery address",
                PickupAddress = "test pickup address",
                BillingRef = "billing",
                ClientRef = "client",
                Products = new List<Product> { new Product
        {
            ProductCode="111",
            ProductDescription="test description",
            Qty=12
        } }
            };

            using var scope = _factory.Services.CreateScope();
            var instructionRepo = scope.ServiceProvider.GetService<IInstructionRepository>();

            if (instructionRepo == null)
            {
                throw new Exception("instructionRepo is null in Test");
            }
            // Act
            var response = await instructionRepo.AddInstruction(instruction);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(instruction, response);
        }

        [Fact]
        public async Task DeleteInstruction()
        {
            // Arrange
            using var scope = _factory.Services.CreateScope();
            var instructionRepo = scope.ServiceProvider.GetService<IInstructionRepository>();

            if (instructionRepo == null)
            {
                throw new Exception("instructionRepo is null in Test");
            }
            // Replace 'instructionId' with the ID of the instruction you want to retrieve.
            var instructionId = 1; // Replace with your specific instruction ID.

            // Act
            var response = await instructionRepo.DeleteInstruction(instructionId);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(instructionId, response.Id); // Assuming 'Id' is the property that represents the instruction's ID.

        }

        [Fact]
        public async Task UpdateInstruction()
        {
            var instruction = new Instruction
            {
                Id = 7,
                InstructionDate = DateTime.UtcNow,
                ClientName = "update test Name",
                DeliveryAddress = "test delivery address",
                PickupAddress = "test pickup address",
                BillingRef = "billing",
                ClientRef = "client",
                Products = new List<Product> { new Product
        {
            ProductCode="111",
            ProductDescription="test description",
            Qty=12
        } }
            };

            // Arrange
            using var scope = _factory.Services.CreateScope();
            var instructionRepo = scope.ServiceProvider.GetService<IInstructionRepository>();

            if (instructionRepo == null)
            {
                throw new Exception("instructionRepo is null in Test");
            }
            // Act
            var response = await instructionRepo.UpdateInstruction(instruction);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(instruction.ClientName, response.ClientName);
        }
    }
}