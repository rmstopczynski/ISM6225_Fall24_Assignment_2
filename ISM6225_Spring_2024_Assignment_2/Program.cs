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
                IList<int> missingNumbers = new List<int>();

                // Edge Case 3: Handles duplicates by storing only unique elements.
                HashSet<int> numSet = new HashSet<int>(nums);

                for (int i = 1; i <= nums.Length; i++)
                {
                    // Edge Case 4: Ensures range is from 1 to n by looping through that range.
                    if (!numSet.Contains(i))
                    {
                        missingNumbers.Add(i);
                    }
                }

                // Edge Case 1: If array is empty, loop does not run, returns empty list.
                // Edge Case 2: If no numbers are missing, nothing is added, returns empty list.
                return missingNumbers;
            }
            catch (Exception)
            {
                // Edge Case 5: Catch unexpected runtime errors, though might not be necessary for simple logic.
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return Array.Empty<int>(); // Edge Case 1: If the array is empty, return an empty array.

                List<int> evens = new List<int>();
                List<int> odds = new List<int>();

                foreach (int num in nums)
                {
                    if (num < 0 || num > 100)
                        continue; // Edge Case 5: Ignore numbers outside the range of 0 to 100.

                    if (num % 2 == 0)
                        evens.Add(num); // Edge Case 2 & 3: Evens go first; handles all-evens and mixes.
                    else
                        odds.Add(num);  // Edge Case 2 & 3: Odds go after evens.
                }

                // Edge Case 4: Add odds after evens to maintain order, including duplicates.
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
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j }; // Edge Case 3 & 4: Handles two elements summing to target and duplicates
                        }
                    }
                }

                return new int[0]; // Edge Case 1 & 2: Empty array or only one element results in no match
            }
            catch (Exception)
            {
                throw; // Edge Case 5 & 6: Unexpected numbers or target range issues (could be handled before the loop if desired)
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3) return 0; // Edge Case 1 & 2: Empty array or fewer than 3 elements
                if (nums.Length == 3) return nums[0] * nums[1] * nums[2]; // Edge Case 3: Exactly 3 elements

                Array.Sort(nums); // Edge Case 4: Sorting handles duplicates naturally
                int n = nums.Length;

                long option1 = (long)nums[n - 1] * nums[n - 2] * nums[n - 3]; // Edge Case 5: Use long to avoid overflow
                long option2 = (long)nums[n - 1] * nums[0] * nums[1];         // Same here for potential large negatives

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
                if (decimalNumber == 0) // Edge Case 1: If the decimal number is 0, return "0".
                    return "0";

                if (decimalNumber < 0) // Edge Case 2: If the decimal number is negative, return an empty string.
                    return string.Empty;

                // Edge Cases 3, 4, and 5 are not needed here:
                // - Case 3 and 4 (int range) are already enforced by the parameter type (int)
                // - Case 5 (non-integer) is impossible because the method input is already an integer

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
                if (nums == null || nums.Length == 0) // Edge Case 1: If the array is empty, return 0.
                    return 0;

                if (nums.Length == 1) // Edge Case 2: Only one element, return it.
                    return nums[0];

                if (nums.Length == 2) // Edge Case 3: Two elements, return the smaller one.
                    return Math.Min(nums[0], nums[1]);

                // Edge Case 4: If array is not rotated (sorted in ascending), return first element.
                if (nums[0] < nums[nums.Length - 1])
                    return nums[0];

                // Edge Case 5: Rotated array — use linear search to find the minimum.
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
                if (x < 0) // Edge Case 1: If the number is negative, return false.
                    return false;

                if (x == 0) // Edge Case 2: If the number is 0, return true.
                    return true;

                if (x < 10) // Edge Case 3: If the number is a single digit, return true.
                    return true;

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
                if (n < 0) // Edge Case 1: If n is negative, return -1.
                    return -1;

                if (n > 30) // Edge Case 6: If n is greater than 30, return -1.
                    return -1;

                if (n == 0) // Edge Case 2: If n is 0, return 0.
                    return 0;

                if (n == 1) // Edge Case 3: If n is 1, return 1.
                    return 1;

                // Edge Case 5: If n is greater than 2, calculate the Fibonacci number using iteration.
                int a = 0;
                int b = 1;
                int result = 0;

                for (int i = 2; i <= n; i++)
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
