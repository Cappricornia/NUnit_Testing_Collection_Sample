
using Collections;
using System.Net.WebSockets;

namespace Collection.UnitTests
{
    public class CollectionTests
    {


        [Test]
        public void Test_Collection_EmptyConstructor()
        {

            // Arrange - empty constructor and Act
            var coll = new Collection<int>();

            // Assert
            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            // Arrange -  constructor and Act
            var coll = new Collection<int>(1);

            // Assert  ->         expected - actual
            Assert.AreEqual(coll.ToString(), "[1]");
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            // Arrange - constructor and Act
            var coll = new Collection<int>(1, 8, 10, 25);

            // Assert  
            Assert.AreEqual(coll.ToString(), "[1, 8, 10, 25]");
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            // Arrange - constructor and Act
            var coll = new Collection<int>(1, 8, 10, 25);

            // Assert  
            // adding a message would help if the test fails as this will show what was expected
            Assert.AreEqual(coll.Count, 4, "Check for count");
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }


        [Test]
        public void Test_Collection_Add()
        {
            // Arrange
            var coll = new Collection<string>("Ivan", "Peter");

            // Act
            coll.Add("Gosho");

            //Assert
            Assert.AreEqual(coll.ToString(), "[Ivan, Peter, Gosho]");

        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            // row 50 - 56 source code ->  get element by index
            var coll = new Collection<int>(5, 6, 7);
            var item = coll[1];

            Assert.That(item.ToString(), Is.EqualTo("6"));
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            // row 58 - 61 source code ->  set element by index
            var coll = new Collection<int>(5, 6, 7);
            coll[1] = 666;

            Assert.That(coll.ToString(), Is.EqualTo("[5, 666, 7]"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            // Arrange and Act
            var coll = new Collection<string>("Ivan", "Peter");

            // Assert -> lambda => get item at index 2 which doesn't exist, Throw exception
            Assert.That(() => { var name = coll[2]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var coll = new Collection<int>(5, 6, 7);


            Assert.That(() => {coll[3] = 666; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        
        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            // Arrange and Act
            var coll = new Collection<int>(2, 3);


            // Assert 
            Assert.That(() => { coll.InsertAt(58, 4); }, Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var coll = new Collection<int>(2, 3);
            coll.InsertAt(0, 666);

            Assert.That(coll.ToString(), Is.EqualTo("[666, 2, 3]"));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var coll = new Collection<int>(2, 3);
            coll.Add(666);

            Assert.That(coll.ToString(), Is.EqualTo("[2, 3, 666]"));
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var coll = new Collection<int>(2, 3, 5);
            var index = coll.Count / 2;
            coll.InsertAt(index, 666);

            Assert.That(coll.ToString(), Is.EqualTo("[2, 666, 3, 5]"));
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var coll = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            var lastIndex = coll.Count;

            coll.InsertAt(lastIndex, 17);

            Assert.That(coll.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]"));
            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));
            Assert.That(coll.Count, Is.EqualTo(17));
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var coll = new Collection<int>(2, 3);
            coll.RemoveAt(0);

            Assert.That(coll.ToString(), Is.EqualTo("[3]"));
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var coll = new Collection<int>(2, 3, 7, 8, 99);
            var index = coll.Count - 1; 
            coll.RemoveAt(index);

            Assert.That(coll.ToString(), Is.EqualTo("[2, 3, 7, 8]"));
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var coll = new Collection<int>(2, 3, 4, 5);
            var index = coll.Count / 2;
            coll.RemoveAt(index);

            Assert.That(coll.ToString(), Is.EqualTo("[2, 3, 5]"));
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            var coll = new Collection<int>(2, 3, 4, 5);
            

            Assert.That(() => { coll.RemoveAt(4); }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
            var coll = new Collection<int>(2, 3, 4, 5);
            
            while (coll.Count > 0)
            {
                coll.RemoveAt(0);
            }

            Assert.That(coll.ToString(), Is.EqualTo("[]"));
        }


        [Test]
        public void Test_Collection_Clear()
        {
            var coll = new Collection<int>(2, 3, 4, 5);

            coll.Clear();   

            Assert.That(coll.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var coll = new Collection<string>(string.Empty);

            Assert.That(coll.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Ana", "Ivan", "Kate");
            var age = new Collection<int>(23, 34, 40);
            var dates = new Collection<DateTime>();

            var nested = new Collection<object>(names, age, dates);

            Assert.That(nested.ToString(), Is.EqualTo("[[Ana, Ivan, Kate], [23, 34, 40], []]"));
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var names = new Collection<string>("Ana", "Ivan", "Merry", "Kate");

            var midindex = names.Count / 2;
            names.Exchange(0, midindex);

            Assert.That(names.ToString(), Is.EqualTo("[Merry, Ivan, Ana, Kate]"));
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var names = new Collection<string>("Ana", "Ivan", "Merry", "Kate");

            
            names.Exchange(0, 3);

            Assert.That(names.ToString(), Is.EqualTo("[Kate, Ivan, Merry, Ana]"));
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {
            var names = new Collection<string>("Ana", "Ivan", "Merry", "Kate");


            Assert.That(() => { names.Exchange(4, 5); }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            var coll = new Collection<int>(1, 2, 3);
            coll.AddRange(new[] { 4, 5,});

            Assert.That(coll.ToString(), Is.EqualTo("[1, 2, 3, 4, 5]"));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }


        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }


        //DDT

        [TestCase("Peter,Maria,Ivan", 0, "Peter")]
        [TestCase("Peter,Maria,Ivan", 1, "Maria")]
        [TestCase("Peter,Maria,Ivan", 2, "Ivan")]
        [TestCase("Peter", 0, "Peter")]

        public void Test_CollectionGetByValidIndex(string data, int index, string expected)
        {
            var coll = new Collection<string>(data.Split(","));

            var actual = coll[index];   

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
