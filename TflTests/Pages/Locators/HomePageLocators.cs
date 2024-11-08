using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TflTests.Pages.HomePageLocators
{
    public static class HomePageLocators
    {
        public static readonly By FromField = By.Id("InputFrom");
        public static readonly By FromFieldErrorMessage = By.Id("InputFrom-error");
        public static readonly By ToFieldErrorMessage = By.Id("InputTo-error");
        public static readonly By ToField = By.Id("InputTo");
        public static readonly By PlanJourneyButton = By.CssSelector("input#plan-journey-button");
        public static readonly By AcceptAllCookiesButton = By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
        public static readonly By AutocompleteSuggestions = By.CssSelector("-suggestion");
    }

}
