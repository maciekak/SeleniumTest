using System;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Drivers.Interfaces;

namespace SeleniumTest.Drivers
{
    public class PlantDriver : IPlantDriver
    {
        private readonly ChromeDriver _driver;

        public PlantDriver(ChromeDriver driver)
        {
            _driver = driver;
        }

        public void Plant()
        {
            AlertCloserDriver.WaitForDocumentReady(_driver, TimeSpan.FromSeconds(10));

            var farm = _driver.FindElementByXPath("//*[@id=\"farm1_pos1_click\"]");
            farm.Click();

            AlertCloserDriver.WaitForDocumentReady(_driver, TimeSpan.FromSeconds(10));

            var carrot = _driver.FindElementByXPath("//*[@id=\"rackitem17\"]");
            carrot.Click();

            var field = _driver.FindElementByXPath("//*[@id=\"field41\"]");
            field.Click();
        }
    }
}
