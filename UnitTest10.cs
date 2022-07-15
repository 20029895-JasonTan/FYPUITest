using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FYPNUnitTest
{
    public class Tests10
    {
        IWebDriver webDriver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {

            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            webDriver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void TestViewMembers()
        {
            By userIdBar = By.Name("UserID");
            By passwordBar = By.Name("Password");

            webDriver.FindElement(userIdBar).SendKeys("JoonHoe");
            webDriver.FindElement(passwordBar).SendKeys("password0");
            IWebElement loginButton = webDriver.FindElement(By.XPath("/html/body/div[1]/form/div/div[3]/input"));
            loginButton.Click();

            IWebElement memberButton = webDriver.FindElement(By.XPath("/html/body/nav/div/ul[1]/li[2]/a"));
            memberButton.Click();

            IWebElement id = webDriver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[1]/th[1]"));
            IWebElement name = webDriver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[1]/th[2]"));
            IWebElement email = webDriver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[1]/th[3]"));
            IWebElement lastLogin = webDriver.FindElement(By.XPath("/html/body/div[1]/table/tbody/tr[1]/th[4]"));

            Assert.IsTrue(id.Text.Equals("ID"));
            Assert.IsTrue(name.Text.Equals("Name"));
            Assert.IsTrue(email.Text.Equals("Email"));
            Assert.IsTrue(lastLogin.Text.Equals("Last Login"));

        }

        [TearDown]
        public void CloseTest()
        {
            webDriver.Close();
        }
    }
}