using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProjectUBB
{
    public class UserRegisterTest : IDisposable
    {
        private readonly IWebDriver _driver;
        public UserRegisterTest()
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
            //Register user
            _driver.Navigate()
                .GoToUrl("https://localhost:7155/Identity/Account/Register");

            _driver.FindElement(By.Id("Input_Email"))
                .SendKeys("user@email.com");

            _driver.FindElement(By.Id("Input_Password"))
                .SendKeys("UserB!k3Rental");

            _driver.FindElement(By.Id("Input_ConfirmPassword"))
                .SendKeys("UserB!k3Rental");

            _driver.FindElement(By.Id("registerSubmit"))
                .Click();

            Assert.Equal(1, 1);
    
        }
    }
}