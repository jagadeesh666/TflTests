using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TflTests.Utils
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string testName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", "Screenshots", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            // Convert to bytes and save
            byte[] screenshotBytes = screenshot.AsByteArray;
            File.WriteAllBytes(filePath, screenshotBytes);

            return filePath;
        }
    }
}
