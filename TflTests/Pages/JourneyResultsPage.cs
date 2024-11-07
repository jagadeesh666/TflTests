using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TflTests.Pages.Locators;
using SeleniumExtras.WaitHelpers;

namespace TflTests.Pages
{
    public class JourneyResultsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public JourneyResultsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public string GetWalkingTime()
        {
            var walkingTimeElement = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(JourneyResultsPageLocators.WalkingTime));
            return walkingTimeElement.Text;

        }

        public string GetCyclingTime()
        {
            var cyclingTimeElement = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(JourneyResultsPageLocators.CyclingTime));
            return cyclingTimeElement.Text;
        }

        public bool AreResultsDisplayed()
        {
            return _wait.Until(d => d.FindElement(JourneyResultsPageLocators.JourneyResults)).Displayed;
        }

        public void ClickEditPreferences()
        {
            var clickEditPreferences = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(JourneyResultsPageLocators.EditPreferences));
            clickEditPreferences.Click();
        }

        public void SelectLeastWalkingDistanceRoute()
        {
            var selectLeastwalkingDistanceRoute = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(JourneyResultsPageLocators.LeastWalkingDistanceRoute));
            selectLeastwalkingDistanceRoute.Click();
        }

        public void SelectUpdateJourneyButton()
        {
            //_driver.FindElement(JourneyResultsPageLocators.UpdateJourneyButton).Click();
            var selectUpdateJourneyButton = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(JourneyResultsPageLocators.UpdateJourneyButton));
            selectUpdateJourneyButton.SendKeys(Keys.Enter);
            selectUpdateJourneyButton.Click();
        }
    }
}
