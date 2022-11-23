using OpenQA.Selenium;
using NavigationSpecflowSelenium.Support;
using NUnit.Framework;
using NavigationSpecflowSelenium.Page_Objects;

namespace NavigationSpecflowSelenium.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        IWebDriver driver = Helper.driver;

        [Given(@"I navigate to ""([^""]*)"" and validate the page title has ""([^""]*)""")]
        public void GivenINavigateToAndValidateThePageTitleHas(string urlToNavigate, string pageTitleText)
        {
            driver.Navigate().GoToUrl(urlToNavigate);
            string pageTitle = driver.Title;
            Assert.IsTrue(pageTitle.Contains(pageTitleText));
        }

        [Given(@"I navigate through main page section by section and back to main page")]
        public void GivenINavigateThroughMainPageSectionBySection()
        {
            TIPO teamInternationalPO = new TIPO(driver);
            int numberOfSections = teamInternationalPO.GetSectionsNumber();

            for (int i = 1; i <= numberOfSections; i++)
            {
                teamInternationalPO.ClickNavigationByIndex(i.ToString());
            }

            teamInternationalPO.ClickTeamInternetionalLogo();
        }

        [Then(@"I Click on ""([^""]*)"" on main page and validate i navigated to the correct page")]
        public void ThenIClickOnOnMainPageValidateINavigatedToTheCorrectPageAndClickTIIconToBackToHomePage(string pageTitle)
        {
            TIPO teamInternationalPO = new TIPO(driver);
            string titleToClick = pageTitle.Split(' ')[0];

            teamInternationalPO.ClickMainPageBannerByText(titleToClick);
            Assert.IsTrue(teamInternationalPO.GetPageHeader().Contains(titleToClick), $"Error! {teamInternationalPO.GetPageHeader()} does not contains {titleToClick}");
        }

        [Then(@"I Click on ""([^""]*)"" on Innovative IT page and validate i navigated to the correct page")]
        public void ThenIClickOnOnInnovativeITPageAndValidateINavigatedToTheCorrectPage(string pageTitle)
        {
            TIPO teamInternationalPO = new TIPO(driver);
            string titleToClick = pageTitle.Split(' ')[0];

            teamInternationalPO.ClickSection2BannerByText(titleToClick);
            Assert.IsTrue(teamInternationalPO.GetPageHeader().Contains(titleToClick), $"Error! {teamInternationalPO.GetPageHeader()} does not contains {titleToClick}");

        }


        [Then(@"I Click on Main page link")]
        public void ThenIClickOnMainPageLink()
        {
            TIPO teamInternationalPO = new TIPO(driver);
            teamInternationalPO.ClickTeamInternetionalLogo();
        }

        [Then(@"I fill Contact Sales Form with first Name ""([^""]*)"", lastName ""([^""]*)"", company ""([^""]*)"", email ""([^""]*)"", phone ""([^""]*)"" and message ""([^""]*)""")]
        public void ThenIFillContactSalesFormWithFirstNameLastNameCompanyEmailPhoneAndMessage(string firstName, string lastName, string company, string email, string phone, string message)
        {
            TIPO teamInternationalPO = new TIPO(driver);

            teamInternationalPO.SetContactSalesFirstName(firstName);
            teamInternationalPO.SetContactSalesLastName(lastName);
            teamInternationalPO.SetContactSalesCompany(company);
            teamInternationalPO.SetContactSalesEmail(email);
            teamInternationalPO.SetContactSalesPhone(phone);
            teamInternationalPO.SetContactSalesMessage(message);

            teamInternationalPO.SetContactSalesCheckBox(true, "1");
            teamInternationalPO.SetContactSalesCheckBox(true, "2");
        }

        [Then(@"I validate I have For Whom section with ""([^""]*)"" Option")]
        public void ThenIValidateIHaveForWhomSectionWithOption(string option)
        {
            TIPO teamInternationalPO = new TIPO(driver);
            
            Assert.IsTrue(teamInternationalPO.GetForWhomOptionByText(option), $"{option} option not found.");
        }

        [Then(@"I navigate to Section ""([^""]*)"" and Validate I am in ""([^""]*)"" page")]
        public void ThenINavigateToSectionAndValidateIAmInPage(string sectionNumber, string pageName)
        {
            TIPO teamInternationalPO = new TIPO(driver);

            teamInternationalPO.ClickNavigationByIndex(sectionNumber);
            Assert.IsTrue(teamInternationalPO.IsSectionHeaderDisplayedByText(pageName), $"page header {pageName} not found.");
        }


        [Then(@"I hover on ""([^""]*)"" and see the text ""([^""]*)"" being displayed in description")]
        public void ThenIHoverOnAndSeeTheTextBeingDisplayedInDescription(string title, string description)
        {
            TIPO teamInternationalPO = new TIPO(driver);
            string text = title.Split(' ')[0];


            teamInternationalPO.hoverOnSectionByText(title);
            Assert.IsTrue(teamInternationalPO.IsDescriptionBeingDisplayedByText(description), $"text with {description} not found");
        }

        [Then(@"I Hover on section 2 ""([^""]*)"" banner and see text ""([^""]*)"" in description")]
        public void ThenIHoverOnSectionBannerAndSeeTextInDescription( string title, string description)
        {
            TIPO teamInternationalPO = new TIPO(driver);
            string text = title.Split(' ')[0];

            teamInternationalPO.hoverOnSection2ByText(text);
            Assert.IsTrue(teamInternationalPO.IsSection2DescriptionBeingDisplayedByText(description), $"text with {description} not found");
        }

        [Then(@"I Click on next location and see the counter was increased and Current location changed")]
        public void ThenIClickOnNextLocationAndSeeTheCounterWasIncreasedAndCurrentLocationChanged()
        {
            TIPO teamInternationalPO = new TIPO(driver);
            string index = teamInternationalPO.GetLocationCurrentPosition();
            string name = teamInternationalPO.GetCurrentLocationName();

            teamInternationalPO.ClickLocationNext();

            string currentIndex = teamInternationalPO.GetLocationCurrentPosition();
            string currentName = teamInternationalPO.GetCurrentLocationName();

            Assert.IsFalse(currentIndex.Equals(index), "index didnt change");
            Assert.IsFalse(currentName.Equals(name), "name didnt change");
        }

        [Then(@"I Click Current Location and see I navigated to ""([^""]*)"" page")]
        public void ThenIClickCurrentLocationAndSeeINavigatedToPage(string pageTitle)
        {
            TIPO teamInternationalPO = new TIPO(driver);

            teamInternationalPO.ClickCurrentLocation();
            string pageHeader = teamInternationalPO.GetPageHeader();

            Assert.IsTrue(pageHeader.Contains(pageTitle), $"Error {pageHeader} does not contains {pageTitle}");
        }

        [Then(@"I Click Top Gun Page Ling to See More and validate I am redirected to ""([^""]*)"" page")]
        public void ThenIClickTopGunPageLingToSeeMoreAndValidateIAmRedirectedTo(string title)
        {
            TIPO teamInternationalPO = new TIPO(driver);

            teamInternationalPO.ClickTopGunSeeMore();
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            string pageHeader = teamInternationalPO.GetPageHeader();
            Assert.IsTrue(pageHeader.Contains(title), $"Error! {pageHeader} does not contains {title}");

            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [Then(@"I Click Team Message, Validate i have ""([^""]*)"" in the text and click Got It")]
        public void ThenIClickTeamMessageValidateIHaveInTheTextAndClickGotIt(string text)
        {
            TIPO teamInternationalPO = new TIPO(driver);

            teamInternationalPO.ClickTeamMessage();

            string message = teamInternationalPO.GetTeamMessageText();

            Assert.IsTrue(message.Contains(text), "Error. Text not found.");

            teamInternationalPO.ClickGotIt();
        }

        [Then(@"I Click Contact Sales")]
        public void ThenIClickContactSales()
        {
            TIPO teamInternationalPO = new TIPO(driver);
            teamInternationalPO.ClickContactSales();
        }

    }
}
