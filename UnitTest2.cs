using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FYPNUnitTest
{
    public class Tests2
    {
        IWebDriver webDriver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {
            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            webDriver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void TestLoginIntoJoonHoesAccount()
        {

            By userIdBar = By.Name("UserID");
            By passwordBar = By.Name("Password");

            webDriver.FindElement(userIdBar).SendKeys("JoonHoe");
            webDriver.FindElement(passwordBar).SendKeys("password0");
            IWebElement loginButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/input"));
            loginButton.Click();

            IWebElement actualResultTest = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[2]/li[1]/p"));
            Assert.IsTrue(actualResultTest.Text.Equals("Welcome Goh Joon Hoe"));
        }

        [TearDown]
        public void CloseTest()
        {
            webDriver.Close();
        }
    }
}