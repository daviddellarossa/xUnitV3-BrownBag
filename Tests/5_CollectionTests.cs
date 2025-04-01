namespace Tests;

// Test collections serve two purposes:
// 1. They delineate the "parallelism" boundary; that is, tests in the same collection will not be run in parallel against each other;
// 2. They offer collection-wide fixtures through the use of ICollectionFixture<TFixtureType>.

// The simplest way to use test collections is simply by name.
// Put two classes into the same named collection, and they can derive benefit #1 above:
[Collection("MyCollection1")]
public class CollectionTests_1_1
{
    // ... tests here ...
}

[Collection("MyCollection1")]
public class CollectionTests_1_2
{
    // ... tests here ...
}


public class MyFixture
{
    // Uses ctor and IDisposable.Dispose to setup/cleanup
}

[CollectionDefinition("MyCollection2")]
public class CollectionClass : ICollectionFixture<MyFixture> { }

[Collection("MyCollection2")]
public class CollectionTests_2_1
{
    // ... tests here ...
}

[Collection("MyCollection2")]
public class CollectionTests_2_2
{
    // ... tests here ...
}

//The collection fixture will be created once before running any test in the collection, and destroyed after all tests in the collection have been run.
//If the tests need access to the fixture, they can take it via their constructor:
[Collection("MyCollection2")]
public class CollectionTests_2_3
{
    public CollectionTests_2_3(MyFixture fixture)
    {
    }

    // ... tests here ...
}
