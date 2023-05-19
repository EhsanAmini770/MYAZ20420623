using Queue;

namespace ArraYQueueTest
{
    public class ArrayQueueTests
    {
        [Fact]
        public void ArrayQueue_Enqueue_Test()
        {
            // Arrange
            var queue = new ArrayQueue<char>("Mehmet"); 

            // Act
            queue.Enqueue('A');

            // Assert
            Assert.Equal(7, queue.Count);
        }

        [Fact]
        public void ArrayQueue_Dequeue_Test()
        {
            // Arrange
            var queue = new ArrayQueue<char>("Mehmet");

            // Act
            var item = queue.Dequeue();

            // Assert
            Assert.Equal(5, queue.Count);
            Assert.Equal('M', item);
        }

        [Fact]
        public void ArrayQueue_Dequeue_Exception_Test()
        {
            // Arrange
            var queue = new ArrayQueue<char>();

            // Act & Assert
            Assert.Throws<Exception>(() => queue.Dequeue());
        }

        [Fact]
        public void ArrayQueue_Peek_Test()
        {
            // Arrange
            var queue = new ArrayQueue<char>("Mehmet");

            // Act
            var item = queue.Peek();

            // Assert
            Assert.Equal('M', item);
        }
    }
}