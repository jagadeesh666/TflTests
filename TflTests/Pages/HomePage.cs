using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TflTests.Pages.HomePageLocators;
public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void EnterFromLocation(string location)
    {
        var fromField = _driver.FindElement(HomePageLocators.FromField);
        fromField.SendKeys(location);
        SelectFromAutocomplete();
    }

    public void EnterToLocation(string location)
    {
        var toField = _driver.FindElement(HomePageLocators.ToField);
        toField.SendKeys(location);
        SelectFromAutocomplete();
    }

    private void SelectFromAutocomplete()
    {
        var suggestions = _wait.Until(d => d.FindElements(HomePageLocators.AutocompleteSuggestions));
        if (suggestions.Count > 0)
        {
            suggestions[0].Click();
        }
    }

    public void ClickPlanJourney()
    {

        var clickPlanJourneyButton = _wait.Until(d => d.FindElements(HomePageLocators.PlanJourneyButton));

        clickPlanJourneyButton[0].Click();
    }


    public void ClickAcceptAllCookies()
    {
        _driver.FindElement(HomePageLocators.AcceptAllCookiesButton).Click();
    }
}

