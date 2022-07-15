using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FYPNUnitTest
{
    public class Tests
    {
        ChromeDriver driver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {
            string URL = "http://fypmovie.azurewebsites.net/Account/Login";
            driver.Navigate().GoToUrl(URL);
        }

        [Test]
        public void TestShowAboutUsWhenClicked()
        {

            IWebElement aboutUs = driver.FindElement(By.XPath("/html/body/nav/div/ul[1]/li[1]/a"));
            aboutUs.Click();

            IWebElement actualResultTest = driver.FindElement(By.XPath("/html/body/div[1]/p"));
            Assert.IsTrue(actualResultTest.Text.Equals("About Us RPMovie provides an outlet for students, lecturers and members of the public to watch the latest up and coming movies at a affordable price. Sign up TODAY to see what movies we will be screening in the near future! Hope to see you there!"));
        }

        [TearDown]
        public void CloseTest()
        {
            driver.Close();
        }
    }
}