using System;
using System.Collections.Immutable;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Drivers.Interfaces;

namespace SeleniumTest.Drivers
{
    public class AlertCloserDriver : IAlertCloserDriver
    {
        private readonly ChromeDriver _driver;

        public AlertCloserDriver(ChromeDriver driver)
        {
            _driver = driver;
        }
        public static void WaitForDocumentReady(IWebDriver driver, TimeSpan waitTime)
        {
            Thread.Sleep(500);
            var wait = new WebDriverWait(driver, waitTime);
            var javascript = driver as IJavaScriptExecutor;
            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript(
                        "if (document.readyState) return document.readyState;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
        public void CloseAllAlerts()
        {
            WaitForDocumentReady(_driver, TimeSpan.FromSeconds(15));

            //TODO: element not clickable
//            var closes = _driver.FindElementsById("newsbox_close")
//                .ToImmutableList();
//
//            closes.ForEach(c => c.Click());
        }
    }
}
