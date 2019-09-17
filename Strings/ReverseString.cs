//https://leetcode.com/problems/reverse-string/
namespace Strings
{
  public class Reverse
  {
    public void ReverseString(char[] s)
    {
      int l = 0, r = s.Length - 1;
      while (l <= r)
      {
        var aux = s[l];
        s[l] = s[r];
        s[r] = aux;
        l++;
        r--;
      }
    }
  }
}