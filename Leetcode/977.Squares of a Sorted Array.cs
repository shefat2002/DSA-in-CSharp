public class Solution {
    // Approach: Square and Sort (O(n log n)) - 26ms
    public int[] SortedSquares(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] *= nums[i];
        }
        Array.Sort(nums);
        return nums;
    }
    // Best Approach: Two Pointers (O(n)) - 1ms
    public int[] SortedSquares(int[] nums){
        int n = nums.Length;
        int l = 0, r = n - 1;
        int[] ans = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            if (Math.Abs(nums[l]) < Math.Abs(nums[r]))
            {
                ans[i] = nums[r] * nums[r--];
            }
            else
            {
                ans[i] = nums[l] * nums[l++];
            }

        }
        return ans;
    }

}