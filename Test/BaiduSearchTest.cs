using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTestFramework.Test
{
    [TestFixture]
    public class BaiduSearchTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // 初始化浏览器（无头模式可加选项）
            var options = new ChromeOptions();
            options.AddArgument("--headless");  // 无头模式适合CI环境
            driver = new ChromeDriver(options);
        }

        [Test]
        public void SearchKeyword_ShouldReturnResults()
        {
            // 1. 打开百度
            driver.Navigate().GoToUrl("https://www.baidu.com");

            // 2. 定位元素并操作
            IWebElement searchBox = driver.FindElement(By.Id("kw"));
            searchBox.SendKeys("Selenium C#" + Keys.Enter);

            // 3. 断言验证
            Assert.That(driver.Title, Does.Contain("Selenium C#"));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();  // 关闭浏览器
        }
    }
}
