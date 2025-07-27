using AutomationTestFramework.BLL.Baidu;
using AutomationTestFramework.Test.CSDN;
using Microsoft.AspNetCore.Mvc;

namespace AutomationTestFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSDNLoginController : ControllerBase
    {
        /// <summary>
        ///  根据输入的关键字进行搜索，如果断言正确，则跳入下一个子链接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("login")]
        public async Task<IActionResult> login(string tel,string passsword)
        {
            var result = new LoginCSDNTest(tel, passsword).LoginWithUsernameAndPassword();
            return Ok(result);
        }
    }
}
