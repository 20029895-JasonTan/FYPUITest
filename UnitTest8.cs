using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FYPNUnitTest
{
    public class Tests8
    {
        IWebDriver webDriver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {

            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            webDriver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void TestLogoutfunction()
        {
            By userIdBar = By.Name("UserID");
            By passwordBar = By.Name("Password");

            webDriver.FindElement(userIdBar).SendKeys("JoonHoe");
            webDriver.FindElement(passwordBar).SendKeys("password0");
            IWebElement loginButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/input"));
            loginButton.Click();

            IWebElement logoutButton = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[2]/li[2]/a"));
            logoutButton.Click();

            IWebElement actualResultTest = webDriver.FindElement(By.XPath("/html/body/div[1]/form/h2"));

            Assert.IsTrue(actualResultTest.Text.Equals("Please Sign In"));

        }

        [TearDown]
        public void CloseTest()
        {
            webDriver.Close();
        }
    }
}