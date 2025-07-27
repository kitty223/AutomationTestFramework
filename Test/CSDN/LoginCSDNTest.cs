
using AutomationTestFramework.Entity;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestFramework.Test.CSDN
{
    [TestFixture]
    public class LoginCSDNTest
    {

        ChromeOptions options = new ChromeOptions();
        private IWebDriver driver;
        private string loginUrl = "https://passport.csdn.net/login";
        private string _username = ""; // 替换为实际用户名
        private string _password = ""; // 替换为实际密码
        public LoginCSDNTest(string username, string password)
        {

            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

          
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _username = username;
            _password = password;
        }

        /// <summary>
        /// 登陆CSDN
        /// </summary>
        /// <returns></returns>

        [Test]
        public async Task<ApiResult> LoginWithUsernameAndPassword()
        {
         
            var result = true;
            // 导航到CSDN登录页面
            driver.Navigate().GoToUrl(loginUrl);

            // 切换到账号密码登录标签
            var passwordLoginTab = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[3]/div/div/span[2]"));///html/body/div[1]/div/div[2]/div[2]/div[3]/div/div/span[2]  login-third-item login-third-passwd
            passwordLoginTab.Click();

        
            // 输入用户名和密码
            var usernameField = driver.FindElement(By.CssSelector("input[placeholder='手机号/邮箱/用户名']"));
            var passwordField = driver.FindElement(By.CssSelector("input[placeholder='密码']"));

            usernameField.Clear();
            usernameField.SendKeys(_username);

            passwordField.Clear();
            passwordField.SendKeys(_password);

            // 点击登录按钮
            var loginButton = driver.FindElement(By.CssSelector(".base-button"));
            loginButton.Click();

            // 等待登录完成
            Thread.Sleep(3000);

            // 验证登录是否成功 - 检查用户头像或用户名是否显示
            try
            {
                
                var userAvatar = driver.FindElement(By.CssSelector(".caption-wrap"));
                Assert.That(userAvatar.Displayed, "未显示滑块登陆失败");
            }
            catch (NoSuchElementException)
            {
                // 检查是否有错误提示
                var errorMsg = driver.FindElement(By.CssSelector(".error-message"));
                Assert.Fail($"登录失败: {errorMsg.Text}");
            }
            finally
            {
                //关闭浏览器
                driver.Quit();
                driver.Dispose();
            }
            return new ApiResult()
            {
                code = 0,
                data = result
            };
        }

    }
}
