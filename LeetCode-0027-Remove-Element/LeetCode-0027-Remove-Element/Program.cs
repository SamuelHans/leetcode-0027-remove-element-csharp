namespace LeetCode_0027_Remove_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Given an integer array 'nums' and an integer 'val', remove all occurrences of 'val' in 'nums' in-place. The order of the elements may be changed. Then return the number of elements in 'nums' which are not equal to val.

            Consider the number of elements in 'nums' which are not equal to 'val' be 'k', to get accepted, you need to do the following things:

            Change the array 'nums' such that the first 'k' elements of 'nums' contain the elements which are not equal to 'val'. The remaining elements of 'nums' are not important as well as the size of 'nums'.
            Return 'k'.

            Custom Judge:

            The judge will test your solution with the following code:

            int[] nums = [...]; // Input array
            int val = ...; // Value to remove
            int[] expectedNums = [...]; // The expected answer with correct length.
                                        // It is sorted with no values equaling val.
            
            int k = removeElement(nums, val); // Calls your implementation
            
            assert k == expectedNums.length;
            sort(nums, 0, k); // Sort the first k elements of nums
            for (int i = 0; i < actualLength; i++) {
                assert nums[i] == expectedNums[i];
            }
            If all assertions pass, then your solution will be accepted.
            
            Example 1:
            
            Input: nums = [3,2,2,3], val = 3
            Output: 2, nums = [2,2,_,_]
            Explanation: Your function should return k = 2, with the first two elements of nums being 2.
            It does not matter what you leave beyond the returned k (hence they are underscores).
            
            Example 2:
            
            Input: nums = [0,1,2,2,3,0,4,2], val = 2
            Output: 5, nums = [0,1,4,0,3,_,_,_]
            Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
            Note that the five elements can be returned in any order.
            It does not matter what you leave beyond the returned k (hence they are underscores).
            
            Constraints:
            
            0 <= nums.length <= 100
            0 <= nums[i] <= 50
            0 <= val <= 100
            */

            //int[] nums = new int[8] { 0, 1, 2, 2, 3, 0, 4, 2 };
            //var val = 2;

            int[] nums = new int[1] { 1 };
            var val = 1;

            var totalNumberOfElementsNotOfVal = Solution.RemoveElement(nums, val);

            Console.WriteLine("The total # of elements not of value {0} is {1}", val, totalNumberOfElementsNotOfVal);
        }

        public class Solution
        {
            public static int RemoveElement(int[] nums, int val)
            {
                // sort array 
                // Return first occurence of val
                // Return last occurrence of val
                // For all occurences +51
                // sort if val returned is 1 >=
                // return array.Length-# of occurences

                Array.Sort(nums);

                if (nums.Length == 0)
                {
                    return 0;
                }

                var firstIndex = Array.FindIndex(nums, n => n == val);

                if ( firstIndex == -1)
                {
                    return nums.Length;
                }
                else
                {
                    var lastIndex = Array.FindLastIndex(nums, n => n == val);
                    var numberOfOccurences = lastIndex - firstIndex + 1;

                    for (int i = firstIndex; i <= lastIndex; i++)
                    {
                        nums[i] = 51;
                    }
                    Array.Sort(nums);

                    return nums.Length - numberOfOccurences;
                }

                return -1;
            }

            // Method 2 - Not mine, but works by having a running tally of the "current" which is like i but only increments on valid #s.
            // On non-matches, updates the current value with num[i].
            // Num[i] always goes up even if matches
            // Current only goes up if not matched
            // Eventually just update all values without val, although last parts of array still original values equal to # of val matches
            public static int RemoveElement2(int[] nums, int val)
            {
                int current = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != val)
                    {
                        nums[current] = nums[i];
                        current++;
                    }
                }
                return current;
            }
        }
    }
}