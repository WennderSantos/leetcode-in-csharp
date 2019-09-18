using System.Collections.Generic;

//https://leetcode.com/problems/letter-combinations-of-a-phone-number/
namespace Strings
{
  public class LetterCombinationsofaPhoneNumber
  {
    public IList<string> LetterCombinations(string digits)
    {
      var res = new List<string>();
      if (digits.Trim().Length == 0)
        return res;

      var arrLetters = new string[]
      {
            "",
            "",
            "abc",
            "def",
            "ghi",
            "jkl",
            "mno",
            "pqrs",
            "tuv",
            "wxyz"
      };

      return Recursive(res, arrLetters, digits, 0, "");
    }

    private IList<string> Recursive(IList<string> res, string[] arrLetters, string digits, int index, string curr)
    {
      if (index == digits.Length)
      {
        res.Add(curr);
        return null;
      }

      var letters = arrLetters[digits[index] - '0'];
      for (var i = 0; i < letters.Length; i++)
        Recursive(res, arrLetters, digits, index + 1, curr + letters[i]);

      return res;
    }
  }
}