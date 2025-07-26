# AutomationTestFramework 
描述：自动化测试框架模块包括上线部署一套流程，下载下来可以替换自己需要写的内容
用到的技术；C# + Selenium + Unit Test + NLog + Docker + Jenkins + ExtentReports

Nuget需要安装这些包：
Microsoft.NET.Test.Sdk<br/>
NUnit<br/>
Selenium.WebDriver<br/>
Selenium.Support<br/>
Selenium.WebDriver.ChromeDriver<br/>
NLog (用于日志记录)<br/>
ExtentReports (用于测试报告生成)<br/>


项目结构：
CSDNLoginTest/    <br/>
├── Properties/   <br/>
├── Services/     <br/>
│   ├── LoggerService.cs   <br/>
│   ├── ReportService.cs   <br/>
│   └── WebDriverService.cs  <br/>
├── Tests/ <br/>
│   └── LoginTests.cs <br/>
├── app.config <br/>
├── NLog.config  <br/>
└── Dockerfile  <br/>
