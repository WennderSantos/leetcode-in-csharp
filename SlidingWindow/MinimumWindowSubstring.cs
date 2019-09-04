using System.Collections.Generic;
using Xunit;

//https://leetcode.com/problems/minimum-window-substring/
namespace SlidingWindow
{
  public class MinimumWindowSubstring
  {
    public static string MinWindow(string s, string t)
    {
      if (t.Length == 0 || s.Length == 0 || t.Length > s.Length)
        return "";

      var memo = new Dictionary<char, int>();
      var sub = new Dictionary<char, int>();
      foreach (var c in t)
      {
        if (memo.ContainsKey(c))
          memo[c]++;
        else
        {
          memo.Add(c, 1);
          sub.Add(c, 0);
        }
      }

      var count = t.Length;
      int i = 0, j = 0, min = int.MaxValue;
      var result = "";

      while (j < s.Length)
      {
        if (memo.ContainsKey(s[j]))
        {
          if (sub[s[j]] < memo[s[j]])
            count--;

          sub[s[j]]++;

          while (count == 0)
          {
            if (min > (j - i))
            {
              min = j - i;
              result = s.Substring(i, j - i + 1);
            }

            if (sub.ContainsKey(s[i]))
            {
              sub[s[i]]--;
              if (sub[s[i]] < memo[s[i]])
                count++;
            }

            i++;
          }
        }

        j++;
      }

      return result;
    }
  }

  public class MinimumWindowSubstring_test
  {

    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "aa", "")]
    [InlineData("", "", "")]
    [InlineData("abaabaa", "aa", "aa")]

    public void MinWindowTest(string s, string t, string want)
    {
      var got = MinimumWindowSubstring.MinWindow(s, t);

      Assert.Equal(got, want);
    }
  }
}