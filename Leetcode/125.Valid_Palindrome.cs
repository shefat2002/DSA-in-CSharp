public class Solution {

    // Approach: String Filtering and Reversal - O(n) 983ms
    public bool IsPalindrome(string s)
    {
        string t = "";
        foreach (char c in s)
        {
            if (Char.IsLetterOrDigit(c)) t += Char.ToLower(c);
        }
        string tt = new string(t.Reverse().ToArray());
        Console.WriteLine(t);
        Console.WriteLine(tt);

        if (t == tt) return true;
        return false;
    }
    
    // Best Approach: Two Pointers - O(n) 98ms
    public bool IsPalindrome(string s)
    {
        int l = 0, r = s.Length - 1;
        while (l < r)
        {
            while (l < r && !Char.IsLetterOrDigit(s[l])) l++;
            while (l < r && !Char.IsLetterOrDigit(s[r])) r--;
            if (Char.ToLower(s[l]) != Char.ToLower(s[r])) return false;
            l++;
            r--;
        }
        return true;
    }
}