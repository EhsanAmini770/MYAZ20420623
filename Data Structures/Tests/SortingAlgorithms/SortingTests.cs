using SortingAlgorithms;

namespace SortingAlgorithmsTests
{
    public class SortingTests
    {

        private int[] Array;
        public SortingTests()
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
        [Fact]
        public void Insertion_Sort_Test()
        {
            //Act
            InsertionSort.Sort(Array);

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

        [Fact]
        public void MergeSort_Test()
        {
            int[] _array = { 10, 20, 50, 30, 40 };
            // Act
            MergeSort.Sort(_array);
            // Assert
            Assert.Collection(_array,
                item => Assert.Equal(10, _array[0]),
                item => Assert.Equal(20, _array[1]),
                item => Assert.Equal(30, _array[2]),
                item => Assert.Equal(40, _array[3]),
                item => Assert.Equal(50, _array[4])
            );
        }
        [Fact]
        public void QuickSort_Test()
        {
            // Act
            int[] _array = { 10, 20, 50, 30, 40 };
            // Act
            Quicksort.Sort(_array);
            // Assert
            Assert.Collection(_array,
                item => Assert.Equal(10, _array[0]),
                item => Assert.Equal(20, _array[1]),
                item => Assert.Equal(30, _array[2]),
                item => Assert.Equal(40, _array[3]),
                item => Assert.Equal(50, _array[4])
            );
        }
        [Fact]
        public void SelectionSort_Test()
        {
            var arr = new char[] { 'a', 'd', 'z', 'c' };
            SelectionSort.Sort(arr);

            Assert.Collection(arr,
                    item => Assert.Equal('a', item),
                    item => Assert.Equal('c', item),
                    item => Assert.Equal('d', item),
                    item => Assert.Equal('z', item));
        }
    }
}