using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Utils;
using WebScrapingShopee.Model;

namespace WebScrapingShopee.Driver
{
    public class WebScraping
    {
        IWebDriver driver = null;
        public WebScraping()
        {
            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();
                //options.AddArgument("--headless");
                options.AddArgument(@"--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36");
                driver = new ChromeDriver(options);

                //driver = new ChromeDriver();
            }
        }
        public string GetProduct(string link, string selectProduct)
        {
            List<Produto> produtos = new List<Produto>();
            string layout = null;
            Console.WriteLine("Iniciando");
            driver.Navigate().GoToUrl(link);

            var util = new Util();

            IWebElement inputElement = driver.FindElement(By.ClassName("shopee-searchbar-input__input"));

            inputElement.SendKeys(selectProduct);

            IWebElement search = driver.FindElement(By.ClassName("shopee-searchbar__search-button"));
            search.SendKeys(Keys.Enter);

            /*if (CheckLayout(driver, "shops__layout-item") > 0)
            {
                layout = "shops__layout-item";
            }
            else if (CheckLayout(driver, "ui-search-layout__item") > 0)
            {
                layout = "ui-search-layout__item";
            }

            switch (layout)
            {
                case "shops__layout-item":
                    produtos = GetProductShops(10);
                    break;
                case "ui-search-layout__item":
                    produtos = GetProductUiSearch(10);
                    break;
            }

            SaveToCsv(produtos, @"C:\Users\kgton\Desktop\ML.csv");

            Console.WriteLine("Finalizado");*/

            util.CloseDriver(driver);

            return "";
        }
    }
}
