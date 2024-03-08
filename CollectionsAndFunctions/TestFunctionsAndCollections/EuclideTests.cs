namespace Learn
{
    public class EuclideTests
    {
        [Fact]
        public void TestGcd_OneCase()
        {
            // given
            uint a = 14;
            uint b = 21;
            // when
            uint g = Euclide.Gcd(a, b);
            // then (verify)
            Assert.Equal(7u, g);
        }

        [Theory]
        [InlineData(14, 21, 7)]
        [InlineData(21, 14, 7)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 21, 1)]
        [InlineData(21, 1, 1)]
        [InlineData(21, 21, 21)]
        public void TestGcd(uint a, uint b, uint expectedResult)
        {
            uint g = Euclide.Gcd(a, b);
            Assert.Equal(expectedResult, g);
        }

        [Theory]
        [InlineData(0, 21)]
        [InlineData(21, 0)]
        [InlineData(0, 0)]
        public void TestGcd_IllegalArgument(uint a, uint b)
        {
            Assert.Throws<ArgumentException>(() => Euclide.Gcd(a, b));
        }
    }
}