using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.BinaryTree;

namespace BinaryTreeTests
{
    public class BinaryTressTests
    {
        private BinaryTree<int> bt;
        public BinaryTressTests()
        {
            // Arrange
            bt = new BinaryTree<int>();
        }

        [Fact]
        public void Insert_Create_Root()
        {
            // Act
            bt.Insert(1);

            // Assert
            Assert.Equal(1, bt.Root.Value);
        }

        [Fact]
        public void Insert_Check_Left_Node()
        {
            // Act
            bt.Insert(1);
            bt.Insert(2);

            // Assert
            Assert.Equal(1, bt.Root.Value);
            Assert.Equal(2, bt.Root.Left.Value);
        }

        [Fact]
        public void Insert_Check_Right_Node()
        {
            // Act
            bt.Insert(1);
            bt.Insert(2);
            bt.Insert(3);

            // Assert
            Assert.Equal(1, bt.Root.Value);
            Assert.Equal(2, bt.Root.Left.Value);
            Assert.Equal(3, bt.Root.Right.Value);
        }

        [Fact]
        public void Multiple_Insertion_Check()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }.ToList()
                .ForEach(x => bt.Insert(x));


            // Assert
            Assert.Equal(1, bt.Root.Value);
            Assert.Equal(2, bt.Root.Left.Value);
            Assert.Equal(3, bt.Root.Right.Value);
            Assert.Equal(4, bt.Root.Left.Left.Value);
            Assert.Equal(5, bt.Root.Left.Right.Value);
            Assert.Equal(6, bt.Root.Right.Left.Value);
            Assert.Equal(7, bt.Root.Right.Right.Value);
        }

        [Fact]
        public void Count_Check()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
            .Where(x => x % 2 == 0)
            .ToList()
            .ForEach(x => bt.Insert(x));

            // Assert
            Assert.Equal(2, bt.Root.Value);
            Assert.Equal(4, bt.Root.Left.Value);
            Assert.Equal(6, bt.Root.Right.Value);
            Assert.Equal(8, bt.Root.Left.Left.Value);
            Assert.Equal(10, bt.Root.Left.Right.Value);

            Assert.Equal(5, bt.Count);
        }


        [Fact]
        public void Level_Order_Traverse_Test()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }
            .ToList()
            .ForEach(x => bt.Insert(x));

            var list = BinaryTree<int>.LevelOrderTraverse(bt.Root);

            // Assert
            Assert.Collection(list,
                item => Assert.Equal(bt.Root.Value, item.Value),
                item => Assert.Equal(2, item.Value),
                item => Assert.Equal(3, item.Value),
                item => Assert.Equal(4, item.Value),
                item => Assert.Equal(5, item.Value),
                item => Assert.Equal(6, item.Value),
                item => Assert.Equal(7, item.Value));

            Assert.Equal(7, bt.Count);

        }

        [Fact]
        public void GetEnumerator_Test()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }
            .ToList()
            .ForEach(x => bt.Insert(x));

            var list = BinaryTree<int>.LevelOrderTraverse(bt.Root);
            // Assert
            Assert.Collection(list,
                item => Assert.Equal(bt.Root.Value, item.Value),
                item => Assert.Equal(2, item.Value),
                item => Assert.Equal(3, item.Value),
                item => Assert.Equal(4, item.Value),
                item => Assert.Equal(5, item.Value),
                item => Assert.Equal(6, item.Value),
                item => Assert.Equal(7, item.Value));

            Assert.Equal(7, bt.Count);

        }


        [Fact]
        public void IsLeaf_Test()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }
            .ToList()
            .ForEach(x => bt.Insert(x));

            // Assert
            Assert.True(bt.Root.Left.Left.IsLeaf);

        }

        [Fact]
        public void IsNotLeaf_Test()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }
            .ToList()
            .ForEach(x => bt.Insert(x));

            // Assert
            Assert.False(bt.Root.Right.IsLeaf);
        }
    }
}
