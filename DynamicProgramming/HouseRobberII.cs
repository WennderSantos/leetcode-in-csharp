using System;
using Xunit;

//https://leetcode.com/problems/house-robber-ii/
namespace DynamicProgramming
{
  public class HouseRobberII
  {
    public static int Rob(int[] nums)
    {
      var buffer1 = new int[nums.Length + 1];
      buffer1[0] = 0; buffer1[1] = nums[0];

      var buffer2 = new int[nums.Length + 1];
      buffer2[0] = 0; buffer2[1] = 0; buffer2[2] = nums[1];

      var result = 0;

      for (var i = 1; i < nums.Length; i++)
      {
        var currVal = nums[i];

        if (i < nums.Length - 1)
        {
          if (currVal + buffer1[i - 1] > buffer1[i])
          {
            buffer1[i + 1] = currVal + buffer1[i - 1];
          }
          else
          {
            buffer1[i + 1] = buffer1[i];
          }
        }

        if (i > 1)
        {
          if (currVal + buffer2[i - 1] > buffer2[i])
          {
            buffer2[i + 1] = currVal + buffer2[i - 1];
          }
          else
          {
            buffer2[i + 1] = buffer2[i];
          }
        }

        result = Math.Max(result, Math.Max(buffer1[i + 1], buffer2[i + 1]));
      }

      return result;
    }
  }

  public class HouseRobberII_test
  {
    [Theory]
    [InlineData(new int[] { 2, 3, 2 }, 3)]
    [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
    public void RobTest(int[] nums, int want)
    {
      var got = HouseRobberII.Rob(nums);

      Assert.Equal(got, want);
    }
  }
}