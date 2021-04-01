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

## 2.  Products Model

Before creating the shopping cart, we must first have some products.

In the real world, products would naturally be stored in a persistent datastore and be modelled in code as a simple property-based class that is easily serialised for transportation.

First, I will create a test that requires three products to be added to a generic list of <T> where T is the base interface of the product type. The three products (Butter, Milk and Bread) will be constructed using a ‘StandardProduct’ class of the base interface.

As there are no functions to evaluate or a DBContext to mock, this test will be very simple and only evaluate the successful construction of a list of products.

Once the test is written, I will create the ‘IProduct’ interface and class to allow the test to compile.

Test succeeded.

Code submitted!

## 3. Shopping Cart

I will write a test that creates an instance of a ‘ShoppingCart’ class that has a function to add a product and another function to retrieve all added products.

The test will succeed if a product can be successfully added and retrieved from the cart.

The Shopping cart will be based on an interface with two functions, ‘AddProduct’, which accepts an ‘ICartProduct’ as its parameter and ‘GetCartProducts’ which returns the list of ‘ICartProduct’.

 ‘ICartProduct’ is an extension of ‘IProduct’ that adds a unit quantity to handle multiple quantity purchases.

An additional test will also be created to check that the quantity is updated if the same product is submitted multiple times.

Test succeeded; code submitted!

## 4. Sub Total

The base cart class will be extended with an additional function to return the subtotal of all items in the cart.

A test will be written to evaluate its success and a new code commit submitted.

## 5. Offers

Offers should be flexible with the ability to create multiple instances from a common interface e.g. Buy-one-get-one-half-price, Buy-one-get-one-free etc.

The offers should also be generic and not hard coded to the product to promote re-use and allow configuration to be persisted in a data store. The target products should therefore be passed in as a parameter to the constructor.

I will create three tests for a ‘Buy2GetItemHalfPrice’ object that takes a cart product list as a parameter and returns a ‘DiscountApplied’ object containing the value of the discount.

The three tests will assert the following criteria:

**Single discount returned** (2 Butter and 1 Bread) – **Discount value £0.50**  
**Multi discount returned** (5 Butter and 3 Bread) – **Discount value £1.00**  
**No discount returned** (1 Butter and 1 Bread) – **Discount is null** 

The code will be implemented and submitted to the repo.

I will now repeat same test and create process for the ‘Buy3Get4thFree’ offer and commit the changes.