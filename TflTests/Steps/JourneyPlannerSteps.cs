using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TflTests.Pages;
using Microsoft.TestPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using Assert = NUnit.Framework.Assert;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TflTests.Steps
{
    [Binding]
    public class JourneyPlannerSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly JourneyResultsPage _resultsPage;

        public JourneyPlannerSteps(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(driver);
            _resultsPage = new JourneyResultsPage(driver);
        }

        [Given(@"I am on the TFL homepage")]
        public void GivenIAmOnTheTFLHomepage()
        {
            _driver.Navigate().GoToUrl("https://tfl.gov.uk");
        }

        [Given(@"I Accept allow all cookies")]
        public void GivenIAcceptAllowAllCookies()
        {
            _homePage.ClickAcceptAllCookies();
        }


        [When(@"I enter ""(.*)"" in the From field")]
        public void WhenIEnterInTheFromField(string location)
        {
            _homePage.EnterFromLocation(location);
        }

        [When(@"I enter ""(.*)"" in the To field")]
        public void WhenIEnterInTheToField(string location)
        {
            _homePage.EnterToLocation(location);
        }

        [When(@"I click Plan Journey on TFL homepage")]
        public void WhenIClickPlanJourneyOnTFLHomepage()
        {
            _homePage.ClickPlanJourney();
        }

        [Then(@"I should see From error message ""([^""]*)"" on TFL homepage")]
        public void ThenIShouldSeeFromErrorMessageOnTFLHomepage(string errorMessage)
        {
            string actualMessage = _homePage.GetFromErrorMessage();
            string expectedMessage = errorMessage;
            
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Actual message does not match expected message");
        }

        [Then(@"I should see To error message ""([^""]*)"" on TFL homepage")]
        public void ThenIShouldSeeToErrorMessageOnTFLHomepage(string errorMessage)
        {
            string actualMessage = _homePage.GetToErrorMessage();
            string expectedMessage = errorMessage;

            Assert.That(actualMessage, Is.EqualTo(expectedMessage), "Actual message does not match expected message");
        }


        [Then(@"I should see an error message on journey results screen")]
        public void ThenIShouldSeeAnErrorMessageOnJourneyResultsScreen()
        {
            Assert.That(_resultsPage.ErrorMessageDisplayed(), "Error Message not displayed");
            //Sorry, we can't find a journey matching your criteria
        }

        [Then(@"I should see journey results")]
        public void ThenIShouldSeeJourneyResults()
        {
            Assert.That(_resultsPage.AreResultsDisplayed(), "Journey results are not displayed");
        }

        [Then(@"I should see walking and cycling times on journey results screen")]
        public void ThenIShouldSeeWalkingAndCyclingTimesOnJourneyResultsScreen()
        {
            var walkingTime = _resultsPage.GetWalkingTime();
            var cyclingTime = _resultsPage.GetCyclingTime();

            Assert.That(!string.IsNullOrEmpty(walkingTime), "Walking time is not displayed");
            Assert.That(!string.IsNullOrEmpty(cyclingTime), "Cycling time is not displayed");
        }

        [Then(@"I select Edit preferences on journey results screen")]
        public void ThenISelectEditPreferencesOnJourneyResultsScreen()
        {
            _resultsPage.ClickEditPreferences();
        }

        [Then(@"I select route with least walking distance on journey results screen")]
        public void ThenISelectRouteWithLeastWalkingDistanceOnJourneyResultsScreen()
        {
            _resultsPage.SelectLeastWalkingDistanceRoute();
        }

        [Then(@"I click update journey button on journey results screen")]
        public void ThenIClickUpdateJourneyButtonOnJourneyResultsScreen()
        {
            _resultsPage.SelectUpdateJourneyButton();
        }

        [Then(@"I view details on journey results screen")]
        public void ThenIViewDetailsOnJourneyResultsScreen()
        {
            _resultsPage.ClickViewDetails();
        }

        [Then(@"the journey results should load within (.*) seconds on journey results screen")]
        public void ThenTheJourneyResultsShouldLoadWithinSecondsOnJourneyResultsScreen(int p0)
        {
            throw new PendingStepException();
        }
    }

}
