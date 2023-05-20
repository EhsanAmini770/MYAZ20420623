using SortingAlgorithms;

namespace SortingAlgorithmsTests
{
    public class BubbleSortTest
    {

        private int[] Array;
        public BubbleSortTest()
        {
            Array = new int[10] { 2, 3, 5, 8, 10, 1, 4, 5, 4, 6 };
        }

        [Fact]
        public void Bubble_Sort_Test()
        {
            //Act
            BubbleSort.Sort(Array);

            //Assert
            Assert.Collection(Array,
                item => Assert.Equal(1, Array[0]),
                item => Assert.Equal(2, Array[1]),
                item => Assert.Equal(3, Array[2]),
                item => Assert.Equal(4, Array[3]),
                item => Assert.Equal(4, Array[4]),
                item => Assert.Equal(5, Array[5]),
                item => Assert.Equal(5, Array[6]),
                item => Assert.Equal(6, Array[7]),
                item => Assert.Equal(8, Array[8]),
                item => Assert.Equal(10, Array[9])
            );
        }
    }
}