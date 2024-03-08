using OpenQA.Selenium;
using Utils;
using WebScrapingShopee.Model;

namespace WebScrapingShopee.Driver
{
    public class WebScraping
    {
        IWebDriver driver = null;
        public WebScraping()
        {
            driver = new Util().InitDriver();
        }
        public string GetProduct(string link, string selectProduct)
        {
            string layout = null;
            var util = new Util();
            List<Produto> produtos = new List<Produto>();

            Console.WriteLine("Iniciando");
            driver.Navigate().GoToUrl(link);



            IWebElement inputElement = driver.FindElement(By.ClassName("shopee-searchbar-input__input"));

            inputElement.SendKeys(selectProduct);

            IWebElement search = driver.FindElement(By.ClassName("shopee-searchbar__search-button"));
            search.SendKeys(Keys.Enter);


           /* if (CheckLayout(driver, "shops__layout-item") > 0)
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
