using System;

//https://leetcode.com/problems/container-with-most-water/
namespace Arrays
{
  public class ContainerWithMostWater
  {
    public int MaxArea(int[] height)
    {
      int max = int.MinValue, l = 0, r = height.Length - 1;

      while (l < r)
      {
        max = Math.Max(max, Math.Min(height[r], height[l]) * (r - l));

        if (height[l] > height[r])
          r--;
        else
          l++;
      }

      return max;
    }
  }
}