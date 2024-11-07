using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TflTests.Pages.Locators
{
    public static class JourneyResultsPageLocators
    {
         public static readonly By WalkingTime = By.CssSelector("a.journey-box.walking .col2.journey-info strong");
         public static readonly By CyclingTime = By.CssSelector("a.journey-box.cycling .col2.journey-info strong");
         public static readonly By JourneyResults = By.CssSelector("span.jp-results-headline");
         public static readonly By EditPreferences = By.XPath("//button[text()='Edit preferences']");
         public static readonly By LeastWalkingDistanceRoute = By.XPath("//label[text()='Routes with least walking']");
         //public static readonly By UpdateJourneyButton = By.CssSelector("input.primary-button plan-journey-button[value='Update journey']");
         public static readonly By UpdateJourneyButton = By.CssSelector("input[type='submit'][value='Update journey'].primary-button.plan-journey-button:nth-of-type(2)");

        //public static readonly By UpdateJourneyButton = By.CssSelector("input[type='submit'][value='Update journey']");
        //var updateJourneyButton = _driver.FindElement(By.XPath("//input[@type='submit' and @value='Update journey']"));


    }
}
