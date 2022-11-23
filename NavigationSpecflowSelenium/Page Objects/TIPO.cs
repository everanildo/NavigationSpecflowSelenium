using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static NavigationSpecflowSelenium.Support.ExtensionMethods;


namespace NavigationSpecflowSelenium.Page_Objects
{
    public class TIPO
    {
        private readonly IWebDriver driver;

        public TIPO(IWebDriver _driver)
        {
            driver = _driver;
        }

        #region xpath

        //main page
        private readonly string sidebarNavigationXpath = ".//div[@id = 'fp-nav']//a";
        private readonly string sidebarOptionIdentifier = ".//div[@id = 'fp-nav']//a//span[@class = 'fp-sr-only']";
        private readonly string pageHeader = ".//h1";
        private readonly string homePageLink = ".//img[@alt = 'TEAM International']";
        private readonly string mainPageBannerByText = ".//h3[contains(text(), '{0}')]";
        private readonly string mainPageBannerDescriptionByTex = ".// p[ contains( text() , '{0}' ) ]";
        private readonly string teamMessage = ".//div[contains(text(), 'TEAM MESSAGE')]";
        private readonly string contactSales = ".//span[contains(text(), 'Contact Sales')]//parent::a";
        private readonly string gotIt = ".//div[contains(text(), 'GOT IT')]";
        private readonly string teamMessageText = ".//div[contains(text(), 'mature global')]";


        //Logistics & transportation form 
        private readonly string firstName = ".//input[@data-id = 'firstName']";
        private readonly string lastName = ".//input[@data-id = 'lastName']";
        private readonly string company = ".//input[@data-id = 'company']";
        private readonly string email = ".//input[@data-id = 'email']";
        private readonly string phone = ".//input[@data-id = 'phone']";
        private readonly string message = ".//input[@data-id = 'message']";
        private readonly string contactSalesCheckbox = "(.//input[@type = 'checkbox'])[{0}]";

        //general for Whom:
        private readonly string forWhomOptionByText = ".//li[contains (text(), '{0}')]";

        //general Section Headers
        private readonly string sectionHeaderById = ".//h2[contains(text(), '{0}')]";
        private readonly string ContactSalesHeaderBy = ".//div[contains(text(), 'Contact Sales')]";

        //Innovative IT Software Services
        private readonly string section2LinksByText = ".//p[contains(text(), '{0}')]";
        private readonly string section2DescriptionByText = ".//p[contains(text(), '{0}')]";

        //Locations
        private readonly string valueBig = ".//span[@class = 'big']";
        private readonly string valueSmall = ".//span[@class = 'small']";
        private readonly string previous = ".//img[contains( @class ,'prev')]";
        private readonly string next = ".//img[contains( @class ,'next')]";
        private readonly string currentLocationName = "(.//div[contains(@class,'slick-track')]//div[@tabindex= 0])[1]//h3";
        private readonly string currentLocationLearnMore = "(.//div[contains(@class,'slick-track')]//div[@tabindex= 0])[1]//a";

        //Top Gun
        private readonly string topGunSeeMore = ".//a[contains(text() , 'see more') ]";



        #endregion


        #region methods

        public void ClickNavigationByIndex(string index)
        {
            driver.FindElement(By.XPath($" ({sidebarNavigationXpath})[{index}] " )).Click();
        }

        public string GetNavigationPageTitlesByIndex(string index)
        {
            return driver.FindElement(By.XPath($" ({sidebarOptionIdentifier})[{index}] ")).Text;
        }

        public string GetPageHeader()
        {
            return driver.FindElement(By.XPath(pageHeader)).Text;
        }

        public int GetSectionsNumber()
        {
            return driver.FindElements(By.XPath(sidebarNavigationXpath)).Count();
        }

        public void ClickMainPageBannerByText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(By.XPath(String.Format(mainPageBannerByText, text))));
            driver.FindElement(By.XPath(String.Format(mainPageBannerByText, text))).Click();
        }

        public void ClickSection2BannerByText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(d => d.FindElement(By.XPath(String.Format(section2LinksByText, text))));
            driver.FindElement(By.XPath(String.Format(section2LinksByText, text))).Click();
        }

        public void ClickTeamInternetionalLogo()
        {
            driver.FindElement(By.XPath(homePageLink)).Click();
        }

        public void SetContactSalesFirstName(string value)
        {
            driver.ScrollEntirePage();
            IWebElement element = driver.FindElement(By.XPath(firstName));

            element.Clear();
            element.SendKeys(value);
        }

        public void SetContactSalesLastName(string value)
        {
            IWebElement element = driver.FindElement(By.XPath(lastName));
            driver.ScrollToElement(element);

            element.Clear();
            element.SendKeys(value);
        }

        public void SetContactSalesCompany(string value)
        {
            IWebElement element = driver.FindElement(By.XPath(company));
            driver.ScrollToElement(element);

            element.Clear();
            element.SendKeys(value);
        }

        public void SetContactSalesEmail(string value)
        {
            IWebElement element = driver.FindElement(By.XPath(email));
            driver.ScrollToElement(element);

            element.Clear();
            element.SendKeys(value);
        }

        public void SetContactSalesPhone(string value)
        {
            IWebElement element = driver.FindElement(By.XPath(phone));
            driver.ScrollToElement(element);

            element.Clear();
            element.SendKeys(value);
        }

        public void SetContactSalesMessage(string value)
        {
            IWebElement element = driver.FindElement(By.XPath(message));
            driver.ScrollToElement(element);

            element.Clear();
            element.SendKeys(value);
        }

        public void SetContactSalesCheckBox(bool status, string index)
        {
            IWebElement element = driver.FindElement(By.XPath(String.Format(contactSalesCheckbox, index)));

            bool currentStatus = Boolean.Parse(element.GetDomProperty("checked"));
            if (currentStatus != status)
                element.Click();
        }

        public bool GetForWhomOptionByText(string text)
        {
            driver.ScrollEntirePage();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.XPath(String.Format(forWhomOptionByText, text))));
            return driver.FindElement(By.XPath(String.Format(forWhomOptionByText, text))).Displayed;
        }

        public bool IsSectionHeaderDisplayedByText(string text)
        {
            Thread.Sleep(3000);
            if (text.Contains("Contact Sales"))            
                return driver.FindElement(By.XPath(ContactSalesHeaderBy)).Displayed;
            else            
                return driver.FindElement(By.XPath(String.Format(sectionHeaderById, text))).Displayed;
        }

        public void hoverOnSectionByText(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.XPath(String.Format(mainPageBannerByText, text))));

            Actions actionhover = new Actions(driver);
            IWebElement moveTo = driver.FindElement(By.XPath(String.Format(mainPageBannerByText, text)));
            actionhover.MoveToElement(moveTo).Perform();
        }

        public bool IsDescriptionBeingDisplayedByText(string text)
        {
            return driver.IsElementBeingDisplayed(String.Format(mainPageBannerDescriptionByTex, text));
        }

        public void hoverOnSection2ByText(string text)
        {
            Actions actionhover = new Actions(driver);
            IWebElement moveTo = driver.FindElement(By.XPath(String.Format(section2LinksByText, text)));
            actionhover.MoveToElement(moveTo).Perform();
        }

        public bool IsSection2DescriptionBeingDisplayedByText(string text)
        {
            return driver.IsElementBeingDisplayed(String.Format(section2DescriptionByText, text));
        }

        public void ClickLocationPrevious()
        {
            driver.FindElement(By.XPath(previous)).Click();
        }

        public void ClickLocationNext()
        {
            driver.FindElement(By.XPath(next)).Click();
        }

        public string GetLocationCurrentPosition()
        {
            return driver.FindElement(By.XPath(valueBig)).Text;
        }

        public string GetLocationTotalPosition()
        {
            return driver.FindElement(By.XPath(valueSmall)).Text;
        }

        public string GetCurrentLocationName()
        {
            return driver.FindElement(By.XPath(currentLocationName)).Text;
        }

        public void ClickCurrentLocation()
        {
            driver.FindElement(By.XPath(currentLocationLearnMore)).Click();
        }

        public void ClickTopGunSeeMore()
        {
            driver.FindElement(By.XPath(topGunSeeMore)).Click();
        }

        public void ClickTeamMessage()
        {
            driver.FindElement(By.XPath(teamMessage)).Click();
        }

        public void ClickContactSales()
        {
            driver.FindElement(By.XPath(contactSales)).Click();
        }


        public void ClickGotIt()
        {
            driver.FindElement(By.XPath(gotIt)).Click();
        }

        public string GetTeamMessageText()
        {
            return driver.FindElement(By.XPath(teamMessageText)).Text;
        }

        #endregion


    }
}
