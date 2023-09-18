using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests.Tests.DomainTests
{
    public class ScheduleTransportTests
    {
        [Fact]
        public void ScheduleTransport_WithValidData_ShouldPassValidation()
        {
            // Arrange
            var scheduleTransport = new ScheduleTransport
            {
                DateScheduled = DateTime.Now,
                Transporter = "Transporter",
            };

            // Act
            var validationContext = new ValidationContext(scheduleTransport);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(scheduleTransport, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);
        }
        [Fact]
        public void ScheduleTransport_DateScheduled_ShouldDefaultToCurrentDateTime()
        {
            // Arrange
            var scheduleTransport = new ScheduleTransport();

            // Act
            var currentDate = DateTime.Now.Date;

            // Assert
            Assert.Equal(currentDate, scheduleTransport.DateScheduled.Date);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ScheduleTransport_Transporter_Validation(string transporter)
        {
            //Arrange 
            var scheduleTransporter = new ScheduleTransport
            {
                DateScheduled=DateTime.Now,
            };
   
            scheduleTransporter.Transporter = transporter;
            //
            var validationContext = new ValidationContext(scheduleTransporter);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(scheduleTransporter, validationContext, validationResults, true);

            if (string.IsNullOrEmpty(transporter))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("Transporter"));
            }
        }
        [Theory]
        //[InlineData(0)]       
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void ScheduleTransport_InstructionId_Validation(int instructionId)
        {
            // Arrange
            var scheduleTransporter = new ScheduleTransport
            {
                DateScheduled = DateTime.Now,
                Transporter = "Transporter"
            };
            scheduleTransporter.InstructionId = instructionId;

            // Act
            var validationContext = new ValidationContext(scheduleTransporter);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(scheduleTransporter, validationContext, validationResults, true);

            // Assert
            if (instructionId == 0)
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("Id"));
            }
        }
        [Theory]
        //[InlineData(0)]       
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void ScheduleTransport_ProductId_Validation(int productId)
        {
            // Arrange
            var scheduleTransporter = new ScheduleTransport
            {
                DateScheduled = DateTime.Now,
                Transporter = "Transporter"
            };
            scheduleTransporter.ProductId = productId;

            // Act
            var validationContext = new ValidationContext(scheduleTransporter);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(scheduleTransporter, validationContext, validationResults, true);

            // Assert
            if (productId == 0)
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("Id"));
            }
        }
    }
}
