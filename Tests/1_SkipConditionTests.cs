namespace Tests;

public class SkipConditionTests
{
    /// <summary>
    /// Test that always passes.
    /// </summary>
    [Fact]
    public void Test_Success()
    {
        Assert.True(true);
    }

    /// <summary>
    /// Test that always fails.
    /// </summary>
    [Fact]
    public void Test_Failure()
    {
        Assert.True(false);
    }

    /// <summary>
    /// Test that is skipped at compile time.
    /// </summary>
    [Fact(Skip = "Test skipped at compile time.")]
    public void Test_Skipped_At_Compile_Time()
    {
        Assert.True(false);
    }

    /// <summary>
    /// Test that is skipped at run time.
    /// </summary>
    [Fact]
    public void Test_In_Fact_Skipped_At_Run_Time()
    {
        bool skipCondition = true;
        Assert.SkipWhen(skipCondition, "Test skipped at run time.");

        Assert.True(false);
    }

    /// <summary>
    /// Theory with a single data point being skipped at run time.
    /// </summary>
    /// <param name="skipCondition"></param>
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Test_In_Theory_Skipped_At_Run_Time_(bool skipCondition)
    {
        Assert.SkipWhen(skipCondition, "Test skipped at run time.");

        Assert.True(true, "Skippable test executed.");
    }

    /// <summary>
    /// Static property to check if a test should be skipped.
    /// </summary>
    /// <returns></returns>
    public static bool CheckIfSkipConditionIsTrue => true;

    /// <summary>
    /// Test that is skipped at run time with a static method.
    /// </summary>
    [Fact(Skip = "Test skipped at runtime based on a static method.", SkipWhen = "CheckIfSkipConditionIsTrue")]
    public void Test_In_Fact_Skipped_At_Run_Time_With_Static_Method()
    {
        Assert.True(false);
    }


    [Fact(Explicit = true)]
    public void Test_Explicit()
    {
        Assert.True(false);
    }
}
