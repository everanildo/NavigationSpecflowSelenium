using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NavigationSpecflowSelenium.Support
{
    public static class ExtensionMethods
    {
        public static void ClickAsScript(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ScrollEntirePage(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static bool IsElementBeingDisplayed(this IWebDriver driver, string xpath, int seconds = 5)
        {
            try
            {
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(seconds));
                return wait.Until(d => d.FindElement(By.XPath(xpath))).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
