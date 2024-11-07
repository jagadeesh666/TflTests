using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

public class WebDriverFactory
{
    public static IWebDriver CreateDriver(string browserType)
    {
        switch (browserType.ToLower())
        {
            case "chrome":
                return new ChromeDriver();
            case "firefox":
                return new FirefoxDriver();
            case "safari":
                return new SafariDriver();
            default:
                throw new ArgumentException($"Browser type {browserType} is not supported.");
        }
    }
}