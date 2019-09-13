using System.Collections.Generic;
using Xunit;

//https://leetcode.com/problems/valid-parentheses/
namespace Strings
{
  public class BalancedString
  {
    public static bool IsValid(string s)
    {
      if (s.Length == 0)
        return true;

      var stack = new Stack<char>();
      var pairs = new Dictionary<char, char>() {
            {')', '('},
            {']', '['},
            {'}', '{'},
        };

      foreach (var c in s)
      {
        if (pairs.ContainsKey(c) && stack.Count > 0)
        {
          if (stack.Peek() != pairs[c])
            return false;

          stack.Pop();
        }
        else
          stack.Push(c);
      }

      return stack.Count == 0;
    }
  }

  public class BalancedString_test
  {
    [Theory]
    [InlineData("", true)]
    [InlineData("{}", true)]
    [InlineData("{]", false)]
    [InlineData("(){}", true)]
    [InlineData("({})", true)]
    [InlineData("({))", false)]
    public void IsValidTest(string s, bool want)
    {
      var got = BalancedString.IsValid(s);

      Assert.Equal(got, want);
    }
  }
}