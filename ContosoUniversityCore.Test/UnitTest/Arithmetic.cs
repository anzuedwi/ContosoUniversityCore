using Xunit;
using ContosoUniversityCore.Test.Utility.Extensions;
using ContosoUniversityCore.Test.Utility.Enums;

namespace ContosoUniversityCore.Test.UnitTest
{
    public class Arithmetic
    {
        [Fact]
        public void MathTest()
        {
            //Arrange
            int operandOne = 10;
            int operandTwo = 5;

            //Act
            int product = operandOne.PerformOperation(Operations.Multiply, operandTwo);
            int sum = operandOne.PerformOperation(Operations.Add, operandTwo);
            int diff = operandOne.PerformOperation(Operations.Subtract, operandTwo);
            int div = operandOne.PerformOperation(Operations.Divide, operandTwo);
            int mod = operandOne.PerformOperation(Operations.Modulus, operandTwo);

            //Assert
            Assert.Equal(50, product);
            Assert.Equal(15, sum);
            Assert.Equal(5, diff);
            Assert.Equal(2, div);
            Assert.Equal(0, mod);

        }
    }
}
