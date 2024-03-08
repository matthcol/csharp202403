using Geometry.Model;

namespace GeometryTests
{
    public class PolygonTests
    {
        // field
        Polygon triangle345;

        public PolygonTests()
        {
            // init common data for all tests
            var pt1 = new Point2D
            {
                X = 1.5,
                Y = 2.25
            };
            var pt2 = new Point2D
            {
                X = 4.5,
                Y = 2.25
            };
            var pt3 = new Point2D
            {
                X = 4.5,
                Y = -1.75
            };
            triangle345 = new Polygon
            {
                Vertices = [pt1, pt2, pt3]
            };
        }

        [Fact]
        public void TestPerimeter_triangle345()
        {
            double actualPerimeter = triangle345.Perimeter;
            Assert.Equal(12.0, actualPerimeter);
        }

        [Fact]
        public void TestArea_triangle345()
        {
            double actualArea = triangle345.Area;
            Assert.Equal(6.0, actualArea);
        }
    }
}