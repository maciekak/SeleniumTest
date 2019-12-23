using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Drivers.Interfaces;

namespace SeleniumTest.Drivers
{
    public class LoginDriver : ILoginDriver
    {
        private readonly ChromeDriver _driver;

        public LoginDriver(ChromeDriver driver)
        {
            _driver = driver;
        }

        public void Login()
        {
            _driver.Url = "https://www.wolnifarmerzy.pl/";
            string loginValue;
            string passwordValue;
            string serverValue;

            Console.WriteLine("Hello World!");
            using (var file = new StreamReader("passes.txt"))
            {
                var passes = file.ReadLine();
                var splitted = passes.Split(' ');
                if (splitted.Length != 3)
                {
                    //TODO: exception with sense
                    throw new Exception();
                }

                loginValue = splitted[0];
                passwordValue = splitted[1];
                serverValue = splitted[2];
            }

            var login = _driver.FindElementByXPath("//*[@id=\"loginusername\"]");
            var password = _driver.FindElementByXPath("//*[@id=\"loginpassword\"]");
            var server = new SelectElement(_driver.FindElementByXPath("//*[@id=\"loginserver\"]"));
            login.SendKeys(loginValue);
            password.SendKeys(passwordValue);
            server.SelectByText(serverValue, true);
            var ll = _driver.FindElementByXPath("//*[@id=\"loginbutton\"]");
            ll.Click();
        }
    }
}
