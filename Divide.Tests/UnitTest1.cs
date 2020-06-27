using System;
using Xunit;

namespace Divide.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10, 10, 1)]
        [InlineData(20, 10, 2)]
        [InlineData(-10, 5, -2)]
        [InlineData(-10, -5, 2)]
        [InlineData(0, -7, 0)]
        [InlineData(27, 10, 2)] // decimal none cause int / int
        [InlineData(5, 10, 0)] // decimal none cause int / int
        [InlineData(-2, -7, 0)]// decimal none cause int / int
        public void CanDivide(int a, int b, double expected)
        {
            //Given
            int number = a;
            int divider = b;
            //When
            var result = Divide.FuncHelper.Divide(number, divider);
            //Then
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivideByZero()
        {
            //Given
            int number = 10;
            int divider = 0;
            //When
            var ex = Assert.Throws<DivideByZeroException>(() => Divide.FuncHelper.Divide(number, divider));
            //Then
            Assert.Equal(new DivideByZeroException().Message, ex.Message);
        }
    }
}
