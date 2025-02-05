using Xunit.Internal;

namespace Tests;

public class TestContextTests
{
    public class ITestOutputHelperTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ITestOutputHelperTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void MyTest()
        {
            _testOutputHelper.WriteLine("Hello from the test!");
            // Perform your assertions here.
        }
    }

    public class TestContextTest
    {
        [Fact]
        public async Task MyTestAsync()
        {
            if(TestContext.Current.CancellationToken.IsCancellationRequested)
            {
                TestContext.Current.AddWarning("Test was cancelled.");
                return;
            }
            else
            {
                TestContext.Current.TestOutputHelper!.WriteLine($"{TestContext.Current.TestMethod!.MethodName} is running");
            }

            // Perform your assertions here.
            await Task.CompletedTask;
        }
    }

    public class ITestContextAccessorTest
    {
        private readonly ITestContextAccessor _testContextAccessor;

        public ITestContextAccessorTest(ITestContextAccessor testContextAccessor)
        {
            _testContextAccessor = testContextAccessor;
        }

        [Fact]
        public void MyTest()
        {
            if (_testContextAccessor.Current.CancellationToken.IsCancellationRequested)
            {
                TestContext.Current.AddWarning("Test was cancelled.");
                return;
            }
            else
            {
                _testContextAccessor.Current.TestOutputHelper!.WriteLine($"{_testContextAccessor.Current.TestMethod!.MethodName} is running");
            }
            // Perform your assertions here.
        }
    }
}
