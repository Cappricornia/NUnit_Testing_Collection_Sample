
using Collections;

namespace Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            // Initialises a new instance of the Cllection<T> class that is an empty 
            var collection = new Collection<int>();

            // call methods to check their functionality
            Console.WriteLine("Current collection: " + collection);

            Console.WriteLine("Collection count: " + collection.Count);
            Console.WriteLine("Collection capacity: " + collection.Capacity);

            collection.Add(6);
            Console.WriteLine("Current collection: " + collection);

            collection.AddRange(8, 9);
            Console.WriteLine("Current collection: " + collection);

            Console.WriteLine("Print the first element " + collection[0]);

            // test setter
            collection[0] = 55; // it was 6
            Console.WriteLine("Print the first element " + collection[0]);


            // current collection [55, 8, 9]
            collection.InsertAt(2, 666); // at index 2, insert 666
            Console.WriteLine("Current collection: " + collection); //// current collection [55, 8, 666, 9]

            collection.Exchange(1, 2); // exchange 1 and 2 indices -> elements
            Console.WriteLine("Current collection: " + collection); //// current collection [55, 666, 8, 9]

            collection.Clear(); 
            Console.WriteLine("Current collection: " + collection); //// current collection []
            */

            Console.WriteLine();
            Console.WriteLine("Collection<T> Examples");
            Console.WriteLine("======================");
            Console.WriteLine();

            Collection<int> nums = new Collection<int>();
            Console.WriteLine($"Empty collection: {nums}");
            Console.WriteLine("Empty collection: " + nums);

            Console.WriteLine($"Count: {nums.Count}. Capacity: {nums.Capacity}");
            Console.WriteLine();

            nums = new Collection<int>(new int[] { 10, 20, 30, 40, 50 });
            Console.WriteLine(nums);
            Console.WriteLine($"Count: {nums.Count}. Capacity: {nums.Capacity}");
            Console.WriteLine();

            nums.Add(60);
            Console.WriteLine("Added: 60");
            Console.WriteLine(nums);
            Console.WriteLine();

            nums[1] = 2000;
            nums[5] = 6000;
            Console.WriteLine("Changed: nums[1] and nums[5]");
            Console.WriteLine(nums);
            Console.WriteLine();

            Console.WriteLine($"num[0] = {nums[0]}");
            Console.WriteLine($"num[3] = {nums[3]}");
            Console.WriteLine();

            var removedItem = nums.RemoveAt(0);
            Console.WriteLine($"Removed item from position #0. Value = {removedItem}");
            Console.WriteLine(nums);
            Console.WriteLine();

            removedItem = nums.RemoveAt(4);
            Console.WriteLine($"Removed item from position #4. Value = {removedItem}");
            Console.WriteLine(nums);
            Console.WriteLine();

            nums.Exchange(0, 1);
            Console.WriteLine("Exchanged positions #0 and #1");
            Console.WriteLine(nums);
            Console.WriteLine();

            for (int i = 1; i <= 20; i++)
                nums.Add(i);
            Console.WriteLine("Added numbers [1...20]");
            Console.WriteLine(nums);
            Console.WriteLine();

            nums.InsertAt(0, 10);
            nums.InsertAt(1, 15);
            Console.WriteLine("Inserted 10 at the start and 15 after it");
            Console.WriteLine(nums);
            Console.WriteLine($"Count: {nums.Count}. Capacity: {nums.Capacity}");
            Console.WriteLine();


        }
    }
}