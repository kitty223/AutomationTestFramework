using AutomationTestFramework.Test;
using Microsoft.AspNetCore.Mvc;

namespace AutomationTestFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Test: ControllerBase
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public async Task<IActionResult> List()
        {
            BaiduSearchTest test = new BaiduSearchTest();
            test.SearchKeyword_ShouldReturnResults();
            return Ok("");
        }
    }
}
