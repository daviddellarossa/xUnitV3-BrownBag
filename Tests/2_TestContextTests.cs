using Xunit.Internal;

namespace Tests;

public class TestContextTests
{
    /// <summary>
    /// Unit tests have access to a special interface which replaces previous usage of Console
    /// and similar mechanisms: ITestOutputHelper.
    /// In order to take advantage of this, just add a constructor argument for this interface,
    /// and stash it so you can use it in the unit test.
    /// </summary>
    public class TestOutputHelperTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TestOutputHelperTest(ITestOutputHelper testOutputHelper)
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

    /// <summary>
    /// TestContext represents information about the current state of the test engine.
    /// It offers properties and methods to access various aspects of the test context, not only for the current test,
    /// such as the test pipeline definition, set or read attachments, a fixture potentially assigned in a previous step
    /// of the pipeline, the cancellationToken, the output stream, etc.
    /// An instance of the ITestOutputHelper (see test above) is also exposed in TestContext.
    /// </summary>
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

    /// <summary>
    /// ITestContextAccessor gives access to the current test context, which is considered to be an immutable snapshot of
    /// the current test state at the time it's retrieved.
    /// The Current property returns the same ITestContext instance as in the previous test.
    /// </summary>
    public class TestContextAccessorTest
    {
        private readonly ITestContextAccessor _testContextAccessor;

        public TestContextAccessorTest(ITestContextAccessor testContextAccessor)
        {
            _testContextAccessor = testContextAccessor;
        }

        [Fact]
        public void MyTest()
        {
            if (_testContextAccessor.Current.CancellationToken.IsCancellationRequested)
            {
                // We can use either the static object ...
                TestContext.Current.AddWarning("Test was cancelled.");
                return;
            }
            else
            {
                // ... or the object injected with the interface.
                _testContextAccessor.Current.TestOutputHelper!.WriteLine($"{_testContextAccessor.Current.TestMethod!.MethodName} is running");
            }
            // Perform your assertions here.
        }
    }
}
