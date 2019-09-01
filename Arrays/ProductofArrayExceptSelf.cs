using Xunit;

//https://leetcode.com/problems/product-of-array-except-self/
namespace Arrays
{
  public class ProductofArrayExceptSelf
  {
    public static int[] ProductExceptSelf(int[] nums)
    {
      var result = new int[nums.Length];
      var temp = 1;
      result[0] = temp;

      for (var i = 1; i < nums.Length; i++)
      {
        temp *= nums[i - 1];
        result[i] = temp;
      }

      temp = 1;

      for (var i = nums.Length - 1; i >= 0; i--)
      {
        result[i] *= temp;
        temp *= nums[i];
      }

      return result;
    }
  }

  public class ProductofArrayExceptSelf_test
  {
    [Fact]
    public void ProductExceptSelfTest()
    {
      var input = new int[] { 1, 2, 3, 4 };
      var want = new int[] { 24, 12, 8, 6 };

      var got = ProductofArrayExceptSelf.ProductExceptSelf(input);
      Assert.Equal(got, want);
    }

    [Fact]
    public void InputContainsZero()
    {
      var input = new int[] { 1, 0, 3, 4 };
      var want = new int[] { 0, 12, 0, 0 };

      var got = ProductofArrayExceptSelf.ProductExceptSelf(input);
      Assert.Equal(got, want);
    }
  }
}