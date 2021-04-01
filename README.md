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

