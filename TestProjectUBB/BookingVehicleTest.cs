using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProjectUBB
{
    public class BookingVehicleTest : IDisposable
    {
        private readonly IWebDriver _driver;
        public BookingVehicleTest()
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

            //Login user
            _driver.Navigate()
            .GoToUrl("https://localhost:7155/Identity/Account/Login");

            _driver.FindElement(By.Id("Input_Email"))
                .SendKeys("user@email.com");

            _driver.FindElement(By.Id("Input_Password"))
                 .SendKeys("UserB!k3Rental");

            _driver.FindElement(By.Id("login-submit"))
                .Click();

            //Book vehicle
            _driver.Navigate()
           .GoToUrl("https://localhost:7155/Users/Booking/Create");

            IWebElement dropdown = _driver.FindElement(By.Id("VehicleId"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("1");
            string chosenVehicle = select.SelectedOption.Text;

            _driver.FindElement(By.Id("StartDateTime"))
                 .SendKeys("16092023" + Keys.Tab + "0945");

            IWebElement input = _driver.FindElement(By.Id("EndDateTime"));
            input.SendKeys("16092023" + Keys.Tab + "1045");

            _driver.FindElement(By.Id("Book"))
                .Click();

            //Check user bookings
            _driver.Navigate()
           .GoToUrl("https://localhost:7155/Users/Booking/UserBookings");

            IWebElement table = _driver.FindElement(By.ClassName("table"));

            IReadOnlyCollection<IWebElement> rows = table.FindElements(By.XPath(".//tbody/tr"));

            Assert.True(rows.Count > 0);

            // Get the first row
            IWebElement firstRow = rows.ElementAt(0);
            // Find all cells (columns) in the current row
            IReadOnlyCollection<IWebElement> cells = firstRow.FindElements(By.TagName("td"));

            Assert.True(cells.Count >= 3);

            string vehicleName = cells.ElementAt(0).Text;
            string startDateTime = cells.ElementAt(1).Text;
            string endDateTime = cells.ElementAt(2).Text;

            Assert.Equal(chosenVehicle, vehicleName);
            Assert.Equal("16.09.2023 09:45:00", startDateTime);
            Assert.Equal("16.09.2023 10:45:00", endDateTime);
    
        }
    }
}