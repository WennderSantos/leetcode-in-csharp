using System;
using System.Collections.Generic;
using Xunit;

//https://leetcode.com/problems/longest-substring-without-repeating-characters/
namespace SlidingWindow
{
  public class LongestSubstringWithoutRepeatingCharacters
  {
    public static int LengthOfLongestSubstring(string s)
    {
      int start = 0, end = 0, result = 0;
      var table = new Dictionary<char, int>();

      while (end < s.Length)
      {
        if (!table.ContainsKey(s[end]) || table[s[end]] < start)
        {
          table[s[end]] = end;
          result = Math.Max(result, end - start + 1);
        }
        else
        {
          start = table[s[end]] + 1;
          table[s[end]] = end;
        }


        end++;
      }

      return result;
    }
  }
  public class LengthOfLongestSubstring_test
  {

    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("pwwkew", 3)]
    [InlineData("bbbbbbb", 1)]
    [InlineData("", 0)]
    [InlineData("tmmzuxt", 5)]
    public void LengthOfLongestSubstringTest(string s, int want)
    {
      var got = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(s);
      Assert.Equal(got, want);
    }
  }
}
