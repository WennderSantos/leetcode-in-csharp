using System.Collections.Generic;

//https://leetcode.com/problems/find-all-anagrams-in-a-string/
namespace SlidingWindow
{
  public class Solution
  {
    public IList<int> FindAnagrams(string s, string p)
    {
      var table = new Dictionary<char, int>();
      foreach (var c in p)
      {
        if (table.ContainsKey(c))
          table[c]++;
        else
          table.Add(c, 1);
      }

      int start = 0, end = 0, counter = table.Count;
      IList<int> result = new List<int>();
      while (end < s.Length)
      {
        var endChar = s[end];
        if (table.ContainsKey(endChar))
        {
          table[endChar]--;
          if (table[endChar] == 0)
            counter--;

          while (counter == 0)
          {
            var startChar = s[start];
            while (!table.ContainsKey(s[start]))
            {
              start++;
              startChar = s[start];
            }

            if (IsAnagram(table, start, end, p))
              result.Add(start);

            if (table[startChar] == 0)
              counter++;

            table[startChar]++;
            start++;
          }
        }

        end++;
      }

      return result;
    }

    public bool IsAnagram(Dictionary<char, int> a, int start, int end, string p)
    {
      if (p.Length != (end + 1 - start))
        return false;

      foreach (var c in a)
      {
        if (c.Value != 0)
          return false;
      }

      return true;
    }
  }
}