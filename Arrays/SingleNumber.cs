using System;
using Xunit;

//https://leetcode.com/problems/single-number/
namespace Arrays
{
  public class SingleNumber
  {
    public static int SingleNum(int[] nums)
    {
      //         var table = new Dictionary<int, int>();
      //         foreach(var num in nums)
      //         {
      //             if(table.ContainsKey(num))
      //                 table[num]++;
      //             else
      //                 table.Add(num, 1);
      //         }

      //         foreach(var item in table)
      //         {
      //             if(item.Value == 1)
      //                 return item.Key;
      //         }

      //         return -1;

      Array.Sort(nums);
      for (var i = 0; i < nums.Length; i++)
      {
        if (i > 0 && nums[i] == nums[i - 1])
          continue;
        if (i + 1 < nums.Length && nums[i] == nums[i + 1])
          continue;

        return nums[i];
      }

      return -1;
    }
  }

  public class SingleNumber_test
  {

    [Theory]
    [InlineData(new int[] { 2, 2, 1 }, 1)]
    [InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
    public void SingleNumTest(int[] nums, int want)
    {
      var got = SingleNumber.SingleNum(nums);

      Assert.Equal(got, want);
    }
  }
}