using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestProjectSelenium
{
    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void MainTitle()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://content-watch.ru/text/";
            Assert.AreEqual("Content Watch - Проверка текста на уникальность", webDriver.Title);
            webDriver.Close();
        }

        [TestCase]
        public void SearchText()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://content-watch.ru/text/";
            IWebElement textArea = webDriver.FindElement(By.Id("text"));
            textArea.SendKeys("Пример текста для проверки уникальности");
            IWebElement button = webDriver.FindElement(By.Id("check-text"));
            button.Click();
            webDriver.Close();
        }

        [TestCase]
        public void ButtonVisible()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://content-watch.ru/text/";
            IWebElement button = webDriver.FindElement(By.Id("check-text"));
            Assert.AreEqual(true, button.Displayed);
            webDriver.Close();
        }

        [TestCase]
        public void NavigateToLogin()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://content-watch.ru/text/";
            webDriver.Navigate().GoToUrl("https://content-watch.ru/login/");
            webDriver.Close();
        }

        [TestCase]
        public void ClickLoginButton()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Url = "https://content-watch.ru/text/";
            IWebElement loginButton = webDriver.FindElement(By.XPath("//a[contains(text(),'Войти')]"));
            loginButton.Click();
            webDriver.Close();
        }
    }
}
