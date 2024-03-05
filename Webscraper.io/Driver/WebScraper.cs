
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebScrapingEasyAutomation.Model;

namespace WebScrapingEasyAutomation.Driver
{
    public class WebScraper
    {
         IWebDriver driver = null;

        public string GetData(string link)
        {
            if (driver == null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("headless");
                driver = new ChromeDriver(chromeOptions);                
            }

            driver.Navigate().GoToUrl(link);

            var items = new List<Item>();

            var elements = driver.FindElements(By.ClassName("card-body"));

            foreach (var element in elements)
            {
                var item = new Item();

                item.Title = element.FindElement(By.ClassName("title")).GetAttribute("title");
                item.Price = element.FindElement(By.ClassName("price")).Text;
                item.Description = element.FindElement(By.ClassName("description")).Text;

                items.Add(item);
            }
            driver.Close();

            return "";

        }
    }
}
