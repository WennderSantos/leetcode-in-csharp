//https://leetcode.com/problems/group-anagrams/

using System;
using System.Collections.Generic;

namespace Strings
{
  public class Anagrams
  {
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
      var table = new Dictionary<string, IList<string>>();

      foreach (var s in strs)
      {
        var ca = s.ToCharArray();
        Array.Sort(ca);
        string key = new string(ca);


        if (!table.ContainsKey(key))
          table.Add(key, new List<string>());

        table[key].Add(s);
      }

      var result = new List<IList<string>>();
      foreach (var item in table)
        result.Add(item.Value);

      return result;
    }
  }
}