public class Solution {
    public int MaxSubArray(int[] nums) {
        int n = nums.Length;
        Int32 ans = Int32.MinValue;
        Int32 temp = 0;

        for (int i = 0; i < n; i++)
        {
            temp += nums[i];
            ans = int.Max(temp, ans);
            if (temp < 0) temp = 0;
        }
        return ans;
    }
}