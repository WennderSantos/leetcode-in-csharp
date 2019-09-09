using System.Collections.Generic;

//https://leetcode.com/problems/valid-anagram/
namespace Strings
{
  public class Solution
  {
    public bool IsAnagram(string s, string t)
    {
      var table = new Dictionary<char, int>();
      foreach (var c in s)
      {
        if (table.ContainsKey(c))
          table[c]++;
        else
          table.Add(c, 1);
      }

      var counter = table.Count;
      foreach (var c in t)
      {
        if (!table.ContainsKey(c))
          return false;

        table[c]--;
        if (table[c] < 0)
          return false;
        else if (table[c] == 0)
          counter--;
      }

      return counter == 0;
    }
  }
}