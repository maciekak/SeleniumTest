using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Url = "https://www.wolnifarmerzy.pl/";
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

            var login = driver.FindElementByXPath("//*[@id=\"loginusername\"]");
            var password = driver.FindElementByXPath("//*[@id=\"loginpassword\"]");
            var server =  new SelectElement(driver.FindElementByXPath("//*[@id=\"loginserver\"]"));
            login.SendKeys(loginValue);
            password.SendKeys(passwordValue);
            server.SelectByText(serverValue, true);
            var k = 3;
            var ll = driver.FindElementByXPath("//*[@id=\"loginbutton\"]");
            ll.Click();
        }
    }
}
