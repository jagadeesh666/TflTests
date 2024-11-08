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
         public static readonly By UpdateJourneyButton = By.XPath("//*[@id='more-journey-options']/div/fieldset/div[2]/div/input[2]");
         public static readonly By ViewDetails = By.XPath("//button[@class='secondary-button show-detailed-results view-hide-details' and @aria-hidden='true']");
         public static readonly By ErrorMessage = By.CssSelector("li.field-validation-error");

    }
}
