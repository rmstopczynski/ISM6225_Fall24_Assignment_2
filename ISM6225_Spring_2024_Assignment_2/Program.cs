using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Edge Cases:
                // 1. If the array is empty, return an empty list.
                // 2. If the array contains all numbers from 1 to n, return an empty list.
                // 3. If the array contains duplicates, ignore them.
                // 4. If the array contains numbers outside the range of 1 to n, ignore them.

                IList<int> missingNumbers = new List<int>();
                HashSet<int> numSet = new HashSet<int> (nums);

                for(int i = 1; i <= nums.Length; i++)
                {
                    if (!numSet.Contains(i))
                    {
                        missingNumbers.Add(i);
                    }
                }
                return missingNumbers; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Edge Cases:
                // 1. If the array is empty, return an empty array.
                // 2. If the array contains only even or only odd numbers, return the array as is.
                // 3. If the array contains both even and odd numbers, separate them into two lists.
                // 4. If the array contains duplicates, keep them in the same order.
                // 5. If the array contains numbers outside the range of 0 to 100, ignore them.

                if (nums == null || nums.Length == 0)
                    return nums ?? Array.Empty<int>();

                List<int> evens = new List<int>();
                List<int> odds = new List<int>();

                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                        evens.Add(num);
                    else
                        odds.Add(num);
                }

                evens.AddRange(odds);
                return evens.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Edge Cases:
                // 1. If the array is empty, return an empty array.
                // 2. If the array contains only one element, return an empty array.
                // 3. If the array contains two elements, check if they sum to the target.
                // 4. If the array contains duplicates, return the indices of the first two numbers that sum to the target.
                // 5. If the array contains numbers outside the range of -10^9 to 10^9, ignore them.
                // 6. If the target is outside the range of -10^9 to 10^9, ignore it.

                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                return new int[0]; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {

                // Edge Cases:
                // 1. If the array is empty, return an empty array.
                // 2. If the array contains only one element, return an empty array.
                // 3. If the array contains two elements, check if they sum to the target.
                // 4. If the array contains duplicates, return the indices of the first two numbers that sum to 

                if (nums == null || nums.Length < 3) return 0;
                if (nums.Length == 3) return nums[0] * nums[1] * nums[2];

                Array.Sort(nums);
                int n = nums.Length;

                // Using long to prevent overflow
                long option1 = (long)nums[n - 1] * nums[n - 2] * nums[n - 3];
                long option2 = (long)nums[n - 1] * nums[0] * nums[1];

                return (int)Math.Max(option1, option2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Edge Cases:
                // 1. If the decimal number is 0, return "0".
                // 2. If the decimal number is negative, return an empty string.
                // 3. If the decimal number is greater than 2^31 - 1, return an empty string.
                // 4. If the decimal number is less than -2^31, return an empty string.
                // 5. If the decimal number is not an integer, return an empty string.

                if (decimalNumber == 0)
                        return "0";
                if (decimalNumber < 0)
                    return string.Empty;

                string binary = string.Empty;
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Edge Cases:
                // 1. If the array is empty, return 0.
                // 2. If the array contains only one element, return that element.
                // 3. If the array contains two elements, return the smaller one.
                // 4. If the array is not rotated, return the first element.
                // 5. If the array is rotated, find the minimum element using binary search.

                if (nums == null || nums.Length == 0)
                    throw new ArgumentException("Array cannot be empty");

                int min = nums[0];
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] < min)
                    {
                        min = nums[i];
                    }
                }
                return min;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Edge Cases:
                // 1. If the number is negative, return false.
                // 2. If the number is 0, return true.
                // 3. If the number is a single digit, return true.

                if (x < 0)
                    return false;

                int original = x;
                int reversed = 0;

                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {

                // Edge Cases:
                // 1. If n is negative, return -1.
                // 2. If n is 0, return 0.
                // 3. If n is 1, return 1.
                // 4. If n is 2, return 1.
                // 5. If n is greater than 2, calculate the Fibonacci number using iteration.
                // 6. If n is greater than 30, return -1. 

                if (n < 0)
                    return -1;
                if (n > 30)
                    return -1;
                if (n == 0)
                    return 0;
                if (n == 1)
                    return 1;

                int a = 0;
                int b = 1;
                int result = 0;

                for(int i = 2; i <= n; i++)
                {
                    result = a + b;
                    a = b;
                    b = result;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
