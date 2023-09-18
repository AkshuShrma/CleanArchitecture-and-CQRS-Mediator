using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTests.Tests.DomainTests
{
    public class ProductTests
    {
        [Fact]
        public void Product_ValidData_ShouldPassValidation()
        {
            // Arrange
            var product = new Product
            {

                ProductDescription = "ProductDescription",
                ProductCode = "ProductCode"
            };

            // Act
            var validationContext = new ValidationContext(product);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);

            // Assert
            Assert.True(isValid);

        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Product_ProductDescription_Validation(string description)
        {
            //Arrange 
            var product = new Product
            {
                ProductCode = "ProductCode"
            };
            product.ProductDescription = description;
            //
            var validationContext = new ValidationContext(product);
            var validationResults= new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);
            if(string.IsNullOrEmpty(description))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("ProductDescription"));
            }
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Product_ProductCode_Validation(string code)
        {
            //Arrange 
            var product = new Product
            {
                ProductDescription = "ProductDescription"
            };
            product.ProductCode = code;
            //
            var validationContext = new ValidationContext(product);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);
            if (string.IsNullOrEmpty(code))
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("ProductCode"));
            }
        }

        [Theory]
        //[InlineData(0)]       
        [InlineData(1)]       
        [InlineData(int.MaxValue)]  
        public void Product_ProductId_Validation(int quantity)
        {
            // Arrange
            var product = new Product
            {
                ProductDescription = "ProductDescription",
                ProductCode = "ProductCode"
            };
            product.Qty = quantity;

            // Act
            var validationContext = new ValidationContext(product);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);

            // Assert
            if (quantity == 0)
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("Id"));
            }
        }
        [Theory]
        //[InlineData(0)]       
        [InlineData(1)]      
        [InlineData(int.MaxValue)] 
        public void Product_InstructionId_Validation(int instructionId)
        {
            // Arrange
            var product = new Product
            {
                ProductDescription = "ProductDescription",
                ProductCode = "ProductCode"
            };
            product.Qty = instructionId;

            // Act
            var validationContext = new ValidationContext(product);
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, validationContext, validationResults, true);

            // Assert
            if (instructionId == 0)
            {
                Assert.False(isValid);
                Assert.Contains(validationResults, result => result.MemberNames.Contains("Id"));
            }
        }
    }
}
