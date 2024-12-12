using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UsabilityTests
{
    [TestFixture]
    public class UsabilityTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestPageLoadTime()
        {
            driver.Navigate().GoToUrl("https://content-watch.ru/text/");
            var loadTime = (DateTime.Now - driver.Navigate().GoToUrl("https://content-watch.ru/text/")).TotalSeconds;
            Assert.Less(loadTime, 5, "Page load time is more than 5 seconds");
        }

        [Test]
        public void TestNavigation()
        {
            driver.Navigate().GoToUrl("https://content-watch.ru/text/");
            IWebElement loginButton = driver.FindElement(By.XPath("//a[contains(text(),'Войти')]"));
            loginButton.Click();
            wait.Until(d => d.Url.Contains("login"));
            Assert.IsTrue(driver.Url.Contains("login"), "Navigation to login page failed");
        }

        [Test]
        public void TestTextInput()
        {
            driver.Navigate().GoToUrl("https://content-watch.ru/text/");
            IWebElement textArea = driver.FindElement(By.Id("text"));
            textArea.SendKeys("Пример текста для проверки уникальности");
            IWebElement button = driver.FindElement(By.Id("check-text"));
            button.Click();
            wait.Until(d => d.FindElement(By.Id("result")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("result")).Displayed, "Result is not displayed");
        }
    }
}
