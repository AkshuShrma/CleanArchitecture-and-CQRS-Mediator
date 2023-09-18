using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XUnitTests.Tests.DomainTests
{
    public class InstructionTests
    {
        [Fact]
        public void Instruction_ValidData_ShouldPassValidation()
        {
            // Arrange
            var instruction = new Instruction
            {
                InstructionDate=DateTime.Now,
                ClientName = "ClientName",
                PickupAddress = "PickupAddress",
                DeliveryAddress = "DeliveryAddress",
                ClientRef = "ClientRef",
                BillingRef = "BillingRef",
                Status = "Status"
            };

            // Act

            //creating a object which provides content for the validation process
            var validationContext = new ValidationContext(instruction);
            //Here we are creating empty lis to store the validation result
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            //here we a validating instruction object against its data annotation
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);

        }
        [Fact]
        public void Instruction_DateScheduled_ShouldDefaultToCurrentDateTime()
        {
            // Arrange
            var instruction = new Instruction();

            // Act
            var currentDate = DateTime.Now.Date;

            // Assert
            Assert.Equal(currentDate, instruction.InstructionDate.Date);
        }

        [Theory]
        [InlineData(null)] // Missing ClientName
        [InlineData("")]   // Empty ClientName
        public void Instruction_ClientName_Validation(string clientName)
        {
            // Arrange
            var instruction = new Instruction
            {
                PickupAddress = "PickupAddress",
                DeliveryAddress = "DeliveryAddress",
                ClientRef = "ClientRef",
                BillingRef = "BillingRef",
                Status = "Status"
            };
            instruction.ClientName = clientName;

            // Act
            var validationContext = new ValidationContext(instruction);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults, true);

            // Assert
            if (string.IsNullOrEmpty(clientName))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("ClientName"));
            }
            else
            {
                Assert.True(isValid);
            }
        }
        [Theory]
        [InlineData(null)] // Missing PickupAddress
        [InlineData("")]   // Empty PickupAddress
        public void Instruction_PickupAddress_Validation(string pickupAddress)
        {
            // Arrange
            var instruction = new Instruction
            {
                ClientName= "ClientName",
                DeliveryAddress = "DeliveryAddress",
                ClientRef = "ClientRef",
                BillingRef = "BillingRef",
                Status = "Status"
            };
            instruction.PickupAddress = pickupAddress;

            // Act
            var validationContext = new ValidationContext(instruction);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults, true);

            // Assert
            if (string.IsNullOrEmpty(pickupAddress))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("PickupAddress"));
            }
            else
            {
                Assert.True(isValid);
            }
        }
        [Theory]
        [InlineData(null)] // Missing DeliveryAddress
        [InlineData("")]   // Empty DeliveryAddress
        public void Instruction_DeliveryAddress_Validation(string deliveryAddress)
        {
            // Arrange
            var instruction = new Instruction
            {
                ClientName = "ClientName",
                PickupAddress = "PickupAddress",
                ClientRef = "ClientRef",
                BillingRef = "BillingRef",
                Status = "Status"
            };
            instruction.PickupAddress = deliveryAddress;

            // Act
            var validationContext = new ValidationContext(instruction);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults, true);

            // Assert
            if (string.IsNullOrEmpty(deliveryAddress))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("DeliveryAddress"));
            }
            else
            {
                Assert.True(isValid);
            }
        }
        [Theory]
        [InlineData(null)] // Missing ClientRef
        [InlineData("")]   // Empty ClientRef
        public void Instruction_ClientRef_Validation(string clientRef)
        {
            // Arrange
            var instruction = new Instruction
            {
                ClientName = "ClientName",
                PickupAddress = "PickupAddress",
                DeliveryAddress = "DeliveryAddress",
                BillingRef = "BillingRef",
                Status = "Status"
            };
            instruction.ClientRef = clientRef;

            // Act
            var validationContext = new ValidationContext(instruction);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults, true);

            // Assert
            if (string.IsNullOrEmpty(clientRef))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("ClientRef"));
            }
            else
            {
                Assert.True(isValid);
            }
        }
        [Theory]
        [InlineData(null)] // Missing BillingRef
        [InlineData("")]   // Empty BillingRef
        public void Instruction_BillingRef_Validation(string billingRef)
        {
            // Arrange
            var instruction = new Instruction
            {
                ClientName = "ClientName",
                PickupAddress = "PickupAddress",
                DeliveryAddress = "DeliveryAddress",
                ClientRef = "ClientRef",
                Status = "Status"
            };
            instruction.ClientRef = billingRef;

            // Act
            var validationContext = new ValidationContext(instruction);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults, true);

            // Assert
            if (string.IsNullOrEmpty(billingRef))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("BillingRef"));
            }
            else
            {
                Assert.True(isValid);
            }
        }
        [Theory]
        [InlineData(null)] // Missing Status
        [InlineData("")]   // Empty Status
        public void Instruction_Status_Validation(string status)
        {
            // Arrange
            var instruction = new Instruction
            {
                ClientName = "ClientName",
                PickupAddress = "PickupAddress",
                DeliveryAddress = "DeliveryAddress",
                ClientRef = "ClientRef",
                BillingRef="BillingRef"
            };
            instruction.ClientRef = status;

            // Act
            var validationContext = new ValidationContext(instruction);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults, true);

            // Assert
            if (string.IsNullOrEmpty(status))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("Status"));
            }
            else
            {
                Assert.True(isValid);
            }
        }
        [Theory]
        //[InlineData(0)]       // Zero is Invalid
        //[InlineData(-1)]      // Negative values are invalid
        [InlineData(1)]       // positive values greater then 0 are allowed
        [InlineData(int.MaxValue)]  // max values are valid
        public void Instruction_InstructionId_Validation(int id)
        {
            // Arrange
            var instruction = new Instruction
            {
                ClientName = "ClientName",
                PickupAddress = "PickupAddress",
                DeliveryAddress = "DeliveryAddress",
                ClientRef = "ClientRef",
                BillingRef = "BillingRef",
                Status = "Status"
            };
            instruction.Id = id;

            // Act
            var validationContext = new ValidationContext(instruction);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instruction, validationContext, validationResults,true);

            // Assert

         
            if (id <= 0)
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("Id"));
            }
            else
            {
                Assert.True(isValid);
            }
        }
       
    }
}

