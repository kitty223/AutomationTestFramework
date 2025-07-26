# AutomationTestFramework 
描述：自动化测试框架模块包括上线部署一套流程，下载下来可以替换自己需要写的内容
用到的技术；C# + Selenium + Unit Test + NLog + Docker + Jenkins + ExtentReports

Nuget需要安装这些包：
Microsoft.NET.Test.Sdk
xunit
xunit.runner.visualstudio
Selenium.WebDriver
Selenium.Support
Selenium.WebDriver.ChromeDriver
NLog (用于日志记录)
ExtentReports (用于测试报告生成)


项目结构：
CSDNLoginTest/
├── Properties/
├── Services/
│   ├── LoggerService.cs
│   ├── ReportService.cs
│   └── WebDriverService.cs
├── Tests/
│   └── LoginTests.cs
├── app.config
├── NLog.config
└── Dockerfile
