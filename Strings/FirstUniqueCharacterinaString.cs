using Xunit;

//https://leetcode.com/problems/first-unique-character-in-a-string/
namespace Strings
{
  public class FirstUniqueCharacter
  {
    public static int FirstUniqChar(string s)
    {
      if (s.Length == 0)
        return -1;

      var table = new int[26];

      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];
        table[c - 'a']++;
      }

      for (var i = 0; i < s.Length; i++)
      {
        var c = s[i];
        if (table[c - 'a'] == 1)
          return i;
      }

      return -1;
    }
  }

  public class FirstUniqueCharacter_test
  {
    [Theory]
    [InlineData("", -1)]
    [InlineData("w", 0)]
    [InlineData("ww", -1)]
    [InlineData("www", -1)]
    [InlineData("leetcode", 0)]
    public void FirstUniqChar_test(string s, int want)
    {
      var got = FirstUniqueCharacter.FirstUniqChar(s);

      Assert.Equal(got, want);
    }
  }
}