using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectUBB
{
   public class RentalCreateTest : IDisposable
{
    private readonly IWebDriver _driver;
    public RentalCreateTest()
    {
        _driver = new ChromeDriver();
    }
    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Fact]
    public void CreateWhenExecutedReturnsCreateView()
    {
        _driver.Navigate()
            .GoToUrl("https://localhost:7155/Vehicle");
        IWebElement vehicleName = _driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[2]"));
        string title = vehicleName.Text;
        var correctTitle = "Quad 4 pedaly";

        Assert.Equal(title, correctTitle);

    }
}
}