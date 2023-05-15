using Array;

namespace ArrayTests
{
    public class ArrayTests
    {
        [Fact]
        public void Array_Count_Test()
        {
            // Arrange
            var array = new Array<string>
            {
                "Ahmet",
                "Mehmet",
                "Can"
            };

            // Act
            int count = array.Count;

            // Assertion
            Assert.Equal(3, count);
            Assert.Equal(4, array.Capacity);
        }

        [Fact]
        public void Array_Add_Test()
        {
            // Arrange
            var array = new Array<string>();
            array.Add("Ahmet");
            array.Add("Mehmet");
            array.Add("Can");
            array.Add("Canan");
            array.Add("Filiz");

            // Act
            int count = array.Count;

            // Assertion
            Assert.Equal(5, count);
            Assert.Equal(8, array.Capacity);
        }

        [Fact]
        public void Array_GetItem_Test()
        {
            // Arrange
            var array = new Array<string>
            {
                "Ahmet",
                "Mehmet"
            };

            // Act
            var item = array.GetItem(1);

            // Assert
            Assert.Equal("Mehmet", item);
        }

        [Fact]
        public void Arrry_Find_Test()
        {
            // Arrange
            var array = new Array<int>
            {
                1,
                2,
                3,
                4
            };

            // Act
            int result = array.Find(2);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Array_GetEnumerator()
        {
            // Arrange
            var array = new Array<string>
            {
                "Ahmet",
                "Mehmet",
                "Can"
            };

            string result = "";
            foreach (var item in array)
            {
                result = string.Concat(result, item);
            }

            Assert.Equal("AhmetMehmetCan", result);
        }

        [Fact]
        public void Array_Constructor_Test()
        {
            // Arrange
            var array = new Array<int>(36, 23, 55, 44, 61);

            // Act
            var result = array.Capacity;

            // Assert
            Assert.Equal(5, result);
            
        }

        [Fact]
        public void Array_SetItem_Test()
        {
            // Arrange
            var numbers = new Array<int>(1, 3, 5, 7);

            // Act
            numbers.SetItem(2, 55);

            // Assert
            Assert.Equal(55, numbers.GetItem(2));
            Assert.True(numbers.GetItem(2).Equals(55));
        }

        [Fact]
        public void Array_GetItem_Exception_Test()
        {
            try
            {
                // Arrange
                var array = new Array<string>
                {
                    "Ahmet",
                    "Mehmet"
                };

                // Act
                var item = array.GetItem(-1);

                // Assert
                Assert.False(true);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void Array_Remove_Test()
        {
            // Arrange
            var array = new Array<int>();
            array.Add(0);
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            // Act
            var item = array.RemoveItem(2);
            var item2 = array.GetItem(2);
            array.RemoveItem(3);

            // Assert
            Assert.Equal(2, item);
            Assert.Equal(3, item2);
            Assert.Equal(4, array.Capacity);
        }

        [Fact]
        public void Array_Copy_Test()
        {
            // Arrange
            var array = new Array<string>();

            array.Add("Ahmet");
            array.Add("Mehmet");
            array.Add("Can");
            array.Add("Deniz");

            // Act
            var newArray = array.Copy(2, 3);
            var item = newArray[0];

            // Assert
            Assert.Equal("Can", item);
        }

        [Fact]
        public void Array_AddRange_Test()
        {
            var array = new Array<int>();
            int[] inList = new int[] { 1, 2, 3, 4, 5 };
            array.AddRange(inList);

            Assert.Collection<int>(array,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item)
                );
        }
        [Fact]
        public void List_Remove_Test()
        {
            // Arrange
            var array = new Array<int>();
            int[] intList = new int[] { 1, 2, 3, 4, 5 };

            // Act
            array.AddRange(intList);

            bool test1 = array.Remove(2);
            bool _ = array.Remove(3);
            bool test2 = array.Remove(7);

            int capacity = array.Capacity;

            // Assert
            Assert.True(test1);
            Assert.True(!test2);
            Assert.Equal(4, capacity);
            Assert.Collection<int>(array,
                item => Assert.Equal(1, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(5, item)
                );
        }
        [Fact]
        public void List_Intersect_Test()
        {
            // Arrange
            var array = new Array<string>() { "Mehmet", "Ali", "Nursel", "Mert", "Emir" };
            string[] stringList = new string[] { "Mehmet", "Ahmet", "Tekin", "Ali", "Naz" };

            // Act
            string[] interList = array.InterSect(stringList);

            // Assert
            Assert.Equal("Mehmet", interList[0]);
            Assert.Equal("Ali", interList[1]);
        }

        [Fact]
        public void List_Union_Test()
        {
            // Arrange
            var array = new Array<string>() { "Mehmet", "Ali", "Nursel", "Mert", "Emir" };
            string[] stringList = new string[] { "Mehmet", "Ahmet", "Tekin", "Ali", "Naz" };

            // Act
            string[] interList = array.Union(stringList);

            // Assert
            Assert.Equal("Mehmet", interList[0]);
            Assert.Equal("Ali", interList[1]);
            Assert.Equal("Nursel", interList[2]);
            Assert.Equal("Mert", interList[3]);
            Assert.Equal("Emir", interList[4]);
            Assert.Equal("Ahmet", interList[5]);
            Assert.Equal("Tekin", interList[6]);
            Assert.Equal("Naz", interList[7]);
        }

        [Fact]
        public void List_Except_Test()
        {
            // Arrange
            var array = new Array<string>() { "Mehmet", "Ali", "Nursel", "Mert", "Emir" };
            string[] stringList = new string[] { "Mehmet", "Ahmet", "Nursel", "Ali", "Mert" };

            // Act
            string[] interList = array.Except(stringList);

            // Assert
            Assert.Equal("Emir", interList[0]);
        }
    }
}