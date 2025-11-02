public class Solution
{
    public int LengthOfLongestSubstring(string s) {
        //dictionary approach
        int n = s.Length;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int l = 0, ans = 0, r = 0;
        while (r < n)
        {
            if (dict.ContainsKey(s[r]))
            {
                // Console.WriteLine("Character " + s[r] + " found at index " + dict[s[r]]);
                l = Math.Max(dict[s[r]] + 1, l);
                // Console.WriteLine("l updated to: " + l);
            }
            dict[s[r]] = r;
            // Console.WriteLine("dict updated: " + s[r] + " -> " + r);
            ans = Math.Max(ans, r - l + 1);
            // Console.WriteLine("ans updated to: " + ans);
            r++;
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        string s;
        s = Console.ReadLine();
        Solution sol = new Solution();
        int res = sol.LengthOfLongestSubstring(s);
        Console.WriteLine(res);
    }
}