//https://leetcode.com/problems/climbing-stairs/
namespace DynamicProgramming
{
  public class Climb
  {
    public int ClimbStairs(int n)
    {
      if (n == 0)
        return 1;

      if (n <= 3)
        return n;

      int last = 3, current = 5;
      n -= 4;

      while (n > 0)
      {
        var aux = current;
        current += last;
        last = aux;
        n -= 1;
      }

      return current;
    }
  }
}