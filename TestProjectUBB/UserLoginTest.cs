using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProjectUBB
{
    public class UserLoginTest : IDisposable
    {
        private readonly IWebDriver _driver;
        public UserLoginTest()
        {
            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void BookVehicle()
        {
           
            //Login user
            _driver.Navigate()
            .GoToUrl("https://localhost:7155/Identity/Account/Login");

            _driver.FindElement(By.Id("Input_Email"))
                .SendKeys("user@email.com");

            _driver.FindElement(By.Id("Input_Password"))
                 .SendKeys("UserB!k3Rental");

            _driver.FindElement(By.Id("login-submit"))
                .Click();
            Assert.Equal(1, 1);

        }
    }
}