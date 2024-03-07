using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Utils;
using WebScrapingZoom.Model;

namespace WebScrapingZoom.Driver
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
        public string GetProduct(string link, string selectProduct, int qtdPages)
        {
            List<Product> produtos = new List<Product>();
            Console.WriteLine("Iniciando");
            driver.Navigate().GoToUrl(link);
            Thread.Sleep(2000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector(\".PrivacyPolicy_Button__1RxwB\").click();");

            var util = new Util();

            IWebElement inputElement = driver.FindElement(By.ClassName("AutoCompleteStyle_input__WAC2Y"));

            inputElement.SendKeys(selectProduct);
            Thread.Sleep(2000);
            inputElement.SendKeys(Keys.Enter);
            IWebElement? nextPage = null;

            for (int i = 0; i < qtdPages; i++)
            {
                var elements = driver.FindElements(By.ClassName("ProductCard_ProductCard__WWKKW"));

                foreach (var element in elements)
                {
                    var produto = new Product();

                    if (util.Exist(By.ClassName("ProductCard_ProductCard_Name__U_mUQ"), element))
                    {
                        produto.Name = element.FindElement(By.ClassName("ProductCard_ProductCard_Name__U_mUQ")).Text;
                    }

                    if (util.Exist(By.ClassName("Text_MobileHeadingS__HEz7L"), element))
                    {
                        produto.Price = element.FindElement(By.ClassName("Text_MobileHeadingS__HEz7L")).Text;
                    }

                    if (util.Exist(By.ClassName("ProductCard_ProductCard_Inner__gapsh"), element))
                    {
                        produto.Link = element.FindElement(By.ClassName("ProductCard_ProductCard_Inner__gapsh")).GetAttribute("href");
                    }

                    if (util.Exist(By.ClassName("ProductCard_ProductCard_Image__4v1sa"), element))
                    {
                        produto.Photo = element.FindElement(By.TagName("img")).GetAttribute("src");
                    }

                    produtos.Add(produto);
                }

                if (util.Exist(By.XPath("//*[@id=\"__next\"]/main/div[1]/ul/li[9]/a"), null, driver))
                {
                    nextPage = driver.FindElement(By.XPath("//*[@id=\"__next\"]/main/div[1]/ul/li[9]/a"))/*.GetAttribute("href")*/;
                    if (nextPage != null)
                    {                        
                        js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                        Thread.Sleep(1000);
                        js.ExecuteScript("document.querySelector(\"#__next > main > div.SearchPageContent_SearchPageContent__Is4eZ > ul > li:nth-child(9) > a\").click();");
                    }
                }
            }

            util.SaveToCsv(produtos, @"C:\Users\kgton\Desktop\Zoom.csv");

            util.CloseDriver(driver);

            return "";
        }
    }
}
