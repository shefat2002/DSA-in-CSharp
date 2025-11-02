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
    
}