namespace Learn
{
    public class EuclideTests
    {
        [Fact]
        public void TestGcd()
        {
            int a = 14;
            int b = 21;
            int g = Euclide.Gcd(a, b);
            Assert.Equal(7, g);
        }
    }
}