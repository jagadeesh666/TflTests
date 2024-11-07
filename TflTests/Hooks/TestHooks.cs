using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using TflTests.Utils;
using BoDi;
using OpenQA.Selenium.Chrome;

[Binding]
public class TestHooks
{
    private static AventStack.ExtentReports.ExtentReports _extent;
    private static ExtentTest _feature;
    private static ExtentTest _scenario;
    private IWebDriver _driver;
    private readonly ScenarioContext _scenarioContext;

    private readonly IObjectContainer _container;

    public TestHooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void InitializeWebDriver()
    {
        _driver = new ChromeDriver(); // Replace ChromeDriver with your desired WebDriver if necessary
        _container.RegisterInstanceAs<IWebDriver>(_driver);
    }

    [AfterScenario]
    public void CleanupWebDriver()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }

    //public TestHooks(IWebDriver driver, ScenarioContext scenarioContext)
    //{
    //    _driver = driver;
    //    _scenarioContext = scenarioContext;
    //}

    //[BeforeTestRun]
    //public static void BeforeTestRun()
    //{
    //    _extent = new AventStack.ExtentReports.ExtentReports();
    //    var reporter = new ExtentHtmlReporter("TestResults/ExtentReport.html");
    //    _extent.AttachReporter(reporter);
    //}

    //[BeforeFeature]
    //public static void BeforeFeature(FeatureContext featureContext)
    //{
    //    _feature = _extent.CreateTest(featureContext.FeatureInfo.Title);
    //}

    //[BeforeScenario]
    //public void BeforeScenario()
    //{
    //    _scenario = _feature.CreateNode(_scenarioContext.ScenarioInfo.Title);
    //}

    //[AfterStep]
    //public void AfterStep()
    //{
    //    if (_scenarioContext.TestError != null)
    //    {
    //        var screenshotPath = ScreenshotHelper.CaptureScreenshot(_driver,
    //            _scenarioContext.ScenarioInfo.Title);
    //        _scenario.Log(Status.Fail, "Step failed. Screenshot: " + screenshotPath);
    //        _scenario.Log(Status.Fail, _scenarioContext.TestError.Message);
    //    }
    //}

    //[AfterScenario]
    //public void AfterScenario()
    //{
    //    _driver?.Quit();
    //}

    //[AfterTestRun]
    //public static void AfterTestRun()
    //{
    //    _extent.Flush();
    //}


}