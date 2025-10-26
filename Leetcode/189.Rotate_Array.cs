public class Solution
{
    // Approach 1: Using temp Array (16ms)
    // public void Rotate(int[] nums, int k)
    // {
    //     int n = nums.Length;
    //     k %= n;
    //     int c = n - k;
    //     int[] temp = new int[c];

    //     for (int i = 0; i < c; i++)
    //     {
    //         temp[i] = nums[i];
    //     }
    //     for (int i = c; i < n; i++)
    //     {
    //         nums[i - c] = nums[i];
    //     }
    //     for(int i = 0; i < c; i++)
    //     {
    //         nums[i + k] = temp[i];
    //     }
    // }
    //Alternate approach 2: Using Extra Array (3ms)
    // public void Rotate(int[] nums, int k)
    // {
    //     int n = nums.Length;
    //     k %= n;
    //     int[] a = new int[n];
    //     int j = 0;
    //     for (int i = n - k; i < n; i++)
    //     {
    //         a[j++] = nums[i];
    //     }
    //     for (int i = 0; i < n - k; i++)
    //     {
    //         a[j++] = nums[i];
    //     }
    //     for (int i = 0; i < n; i++)
    //     {
    //         nums[i] = a[i];
    //     }
    // }
    // Alternate approach 3: Using Reversal Algorithm (0ms)
    public void Rotate(int[] nums, int k)
    {
        int n = nums.Length;
        k %= n;

        Reverse(nums, 0, n - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, n - 1);
    }
    private void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            int temp = nums[start];
            nums[start] = nums[end];
            nums[end] = temp;
            start++;
            end--;
        }
    }

    // Test the Rotate method
    // public static void Main(string[] args)
    // {
    //     int n = Convert.ToInt32(Console.ReadLine());
    //     int[] nums = new int[n];
    //     for (int i = 0; i < n; i++)
    //     {
    //         nums[i] = Convert.ToInt32(Console.ReadLine());
    //     }
    //     int k = Convert.ToInt32(Console.ReadLine());
    //     Rotate(nums, k);
    //     Console.WriteLine("Rotated Array: " + string.Join(", ", nums));
    // }
}