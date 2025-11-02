public class Solution {

    // Approach: Sliding Window with HashSet (O(n)) - 6ms
    public int LengthOfLongestSubstring(string s)
    {
        int l = 0, r = 1;
        int n = s.Length;
        if (n < 2) return n;
        HashSet<char> st = new HashSet<char>();
        int ans = 0;
        st.Add(s[0]);
        while (r < n)
        {
            if (st.Add(s[r]))
            {
                r++;
            }
            else
            {
                bool b = st.Remove(s[l++]);
            }
            ans = Math.Max(ans, (r - l));
        }
        return ans;
    }
    
    // Approach: Sliding Window with Dictionary (O(n))
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
}