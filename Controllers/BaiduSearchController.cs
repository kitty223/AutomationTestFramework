using AutomationTestFramework.BLL.Baidu;
using Microsoft.AspNetCore.Mvc;

namespace AutomationTestFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiduSearchController : Controller
    {
        public BaiduSearchController()
        {

        }
        /// <summary>
        ///  根据输入的关键字进行搜索，如果断言正确，则跳入下一个子链接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("searchContent")]
        public async Task<IActionResult> SearchContent(string keyword)
        {
            var result = new BaiduSearchTest().SearchForSeleniumInBaidu(keyword);
            return Ok(result);
        }
    }
}
