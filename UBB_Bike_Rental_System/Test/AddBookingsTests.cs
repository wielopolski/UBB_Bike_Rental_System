using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NuGet.ContentModel;
using Xunit;

namespace UBB_Bike_Rental_System.Test;

public class AddBookingsTests : IDisposable
{
    private readonly IWebDriver _driver;
    public AddBookingsTests()
    {
        _driver = new ChromeDriver();
    }
    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Fact]
    public void Create_WhenExecuted_ReturnsCreateView()
    {
        _driver.Navigate()
            .GoToUrl("https://localhost:7155");

        Assert.Equal("Create - EmployeesApp", _driver.Title);
        Assert.Contains("Please provide a new employee data", _driver.PageSource);
    }
}
