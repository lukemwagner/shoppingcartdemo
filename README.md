# Shopping cart demo exercise

## Project assumptions:

I will create a .Net Core 5 solution containing a class library and a unity test project.

Due to being a small demonstration, the class library will use a single namespace.

For simplicity, Unit testing will be constructed using MSTest due to its zero dependency.

Unit tests will remain in the unit test project and be consolidated to a single file for ease of review.

At each step of the project, I will document my progress and decision making in this Readme file and commit it to the git repo along with the code changes.

## 1. Bootstrap the project:

I created a new .Net Core solution containing a class library and a Unit test library using the following Dotnet CLI commands:

```
dotnet new sln
dotnet new gitignore
dotnet new classlib -o ShoppingCart.Lib
dotnet sln add ShoppingCart.Lib/ShoppingCart.Lib.csproj
dotnet new mstest -o ShoppingCart.Test
dotnet sln add ShoppingCart.Test/ShoppingCart.Test.csproj
dotnet add ShoppingCart.Test/ShoppingCart.Test.csproj reference ShoppingCart.Lib/ShoppingCart.Lib.csproj
```

To check the project was all bootstrapped correctly and complies without issues, I created a very simple initial test by adding a “SayHello” function to the class library’s default class and a corresponding unit test in the default test class.

The project complies and the test succeeds without issues.

The initial commit will now be made to the Git repo.

A quick clean-up is done to remove the default class and bootstrap test.

**Now onto the fun stuff!**

## 2. Master Tests

The primary objective is to create a shopping cart to hold a number of products that conform to the given specification of requirements.

In order to meet these requirements, I will adopt a TDD approach and first create the final tests to clearly define the successful alignment to the end goal.  

Initially, these tests will not be fully implemented as there would be too many moving parts for an initial test scope. Their job is act as simple placeholders to ensure the direction of all other tests finally accumulate to their successful implementation.

Long term ‘failing’ tests would not be ideal in a larger project, but as this short exercise it fits my current objective well.

Definition of the master test scenarios:

- **Test 1** (1 bread, 1 butter and 1 milk) **should total £2.95**
- **Test 2** (2 butter and 2 bread) **should total £3.10**
- **Test 3** (4 milk) should total £3.45
- **Test 4** (2 butter, 1 bread and 8 milk) **should total £9.00**

I will create a new test class called ‘CartTests’ and implement these four tests with a simple ‘Assert.Fail’ and commit the changes.
