using AutomationTestFramework.Entity;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTestFramework.BLL.Baidu
{
    [TestFixture]
    public class BaiduSearchTest
    {
        private IWebDriver driver = new ChromeDriver();
        private string testUrl = "https://www.baidu.com";

        /// <summary>
        /// 搜索关键字并验证搜索结果
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        [Test]
        public  async Task<ApiResult> SearchForSeleniumInBaidu(string keyword)
        {
            var result = true;
            try
            {
                // 导航到百度首页
                driver.Navigate().GoToUrl(testUrl);
                driver.Manage().Window.Maximize();
                // 设置隐式等待时间
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                // 定位搜索框并输入搜索词
                IWebElement searchBox = driver.FindElement(By.Id("kw"));
                searchBox.SendKeys(keyword);

                // 定位搜索按钮并点击
                IWebElement searchButton = driver.FindElement(By.Id("su"));
                searchButton.Click();

                // 等待搜索结果加载
                System.Threading.Thread.Sleep(2000);

                // 验证搜索结果
                Assert.That(driver.Title, Does.Contain(keyword),"搜索结果与标题不匹配");
                //然后在验证正确的情况下跳转第一个链接 
                IWebElement firstLink = driver.FindElement(By.XPath("//*[@id=\'3001\']/div/div[1]/div/div/h3/div/a"));
                firstLink.Click();
                System.Threading.Thread.Sleep(2000);
                Assert.That(driver.Title, Does.Contain(keyword), "搜索结果与标题不匹配");

            }
            catch (AssertionException ex)
            {
                Console.WriteLine("异常原因是:" + ex.Message);
                result = false;
            }
            finally
            {
                // 关闭浏览器
                driver.Quit();
            }
            return new ApiResult()
            {
                code = 0,
                data = result
            };

        }
    }
}
