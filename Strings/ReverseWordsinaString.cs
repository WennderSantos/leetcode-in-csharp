using System.Text;
using Xunit;

//https://leetcode.com/problems/reverse-words-in-a-string/
namespace Strings
{
  public class ReverseWords
  {
    public static string Reverse(string s)
    {
      s = s.Trim();
      var result = new StringBuilder();
      var words = s.Split(" ");
      for (var i = words.Length - 1; i >= 0; i--)
      {
        if (words[i] != "")
        {
          result.Append(words[i]);
          if (i > 0)
            result.Append(" ");
        }
      }

      return result.ToString();
    }
  }

  public class ReverseWords_test
  {
    [Theory]
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world!  ", "world! hello")]
    [InlineData("a good   example", "example good a")]
    public void ReverseTest(string s, string want)
    {
      var got = ReverseWords.Reverse(s);

      Assert.Equal(got, want);
    }
  }
}