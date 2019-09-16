//https://leetcode.com/problems/find-the-difference/
using System;

namespace Strings
{
  public class FindDifference
  {
    public char FindTheDifference(string s, string t)
    {
      var sCharArray = s.ToCharArray();
      var tCharArray = t.ToCharArray();
      Array.Sort(sCharArray);
      Array.Sort(tCharArray);

      for (var i = 0; i < s.Length; i++)
      {
        if (sCharArray[i] != tCharArray[i])
          return tCharArray[i];
      }

      return tCharArray[tCharArray.Length - 1];
    }
  }
}