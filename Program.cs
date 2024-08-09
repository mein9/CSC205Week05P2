using System.Diagnostics;

namespace CSC205Week05P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "numbers.txt";
            Stopwatch stopwatch = new Stopwatch();
            Method01(fileName, 1000, 1, 1001);
            string[] lines = File.ReadAllLines(fileName);
            int[] values = new int[lines.Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToInt32(lines[i]);
            }
            stopwatch.Start();
            Console.WriteLine("starting ... ");
            Method02(values);
            Console.WriteLine("done! ... ");
            stopwatch.Stop();
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        // Generates random ints and within a given range and writes them to a file
        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        {
            // Open a StreamWriter to write to specified file
            using (var writer = new StreamWriter(fileName))
            {
                // Generate random object
                Random r = new Random();
                int number = 0;
                {
                    // Generate random numbers in range and write to file
                    for (int i = 1; i < total; i++)
                    {
                        number = r.Next(lowerRange, upperRange);
                        writer.WriteLine(number);
                    }
                }
            }
        }

        // Sorts an array of ints using selection sort
        static void Method02(int[] arr)
        {
            // Iterate through the array
            for (int start = 0; start < arr.Length - 1; start++)
            {
                int posMin = start; // marks first spot as minimum

                // find the smallest element in the remaining unsorted portion of the array
                for (int i = start + 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[posMin])
                    {
                        posMin = i; // Updates posMin if a smaller element is found
                    }
                }
                // Swap the found minimum with the element at the current position
                int tmp = arr[start];
                arr[start] = arr[posMin];
                arr[posMin] = tmp;
            }
        }
    }
}