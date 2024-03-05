using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebScrapingML.Model;
using Utils;


namespace WebScrapingML.Driver
{
    public class WebScraping
    {
        IWebDriver driver = null;
        public WebScraping()
        {
            if (driver == null)
            {
                /*ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                driver = new ChromeDriver(options);*/
                driver = new ChromeDriver();
            }
        }
        public string GetProduct(string link, string selectProduct)
        {
            var util = new Util();
            List<Produto> produtos = new List<Produto>();
            string layout = null;
            Console.WriteLine("Iniciando");
            driver.Navigate().GoToUrl(link);            

            IWebElement inputElement = driver.FindElement(By.Id("cb1-edit"));

            inputElement.SendKeys(selectProduct);

            IWebElement search = driver.FindElement(By.ClassName("nav-search-btn"));
            search.Click();

            if (CheckLayout(driver, "shops__layout-item") > 0)
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

            util.SaveToCsv(produtos, @"C:\Users\kgton\Desktop\ML.csv");

            Console.WriteLine("Finalizado");

            util.CloseDriver(driver);

            return "";
        }        
        public int CheckLayout(IWebDriver driver, string layCss)
        {
            var elements = driver.FindElements(By.ClassName(layCss));
            return elements.Count;
        }
        public List<Produto> GetProductShops(int qtdPages)
        {
            string nextPage = null;
            var util = new Util();
            List<Produto> produtos = new List<Produto>();

            for (int i = 0; i < qtdPages; i++)
            {
                var elements = driver.FindElements(By.ClassName("shops__layout-item"));
                foreach (var element in elements)
                {
                    var produto = new Produto();

                    produto.Name = element.FindElement(By.ClassName("ui-search-item__title")).Text;
                    produto.Price = element.FindElement(By.ClassName("andes-money-amount__fraction")).Text;
                    //produto.Freight = element.FindElement(By.ClassName("ui-pb-highlight")).Text;
                    produto.Link = element.FindElement(By.ClassName("ui-search-link__title-card")).GetAttribute("href");
                    produto.Photo = element.FindElement(By.ClassName("ui-search-result-image__element")).GetAttribute("src");

                    produtos.Add(produto);
                }

                if (util.Exist(driver, By.XPath(@"//*[@id='root-app']/div/div[3]/section/nav/ul/li[12]/a")))
                {
                    nextPage = driver.FindElement(By.XPath(@"//*[@id='root-app']/div/div[3]/section/nav/ul/li[12]/a")).GetAttribute("href");
                    driver.Navigate().GoToUrl(nextPage);
                    Thread.Sleep(2000);
                }
            }

            return produtos;
        }
        public List<Produto> GetProductUiSearch(int qtdPages)
        {
            string nextPage = null;
            var util = new Util();
            List<Produto> produtos = new List<Produto>();

            for (int i = 0; i < qtdPages; i++)
            {
                var elements = driver.FindElements(By.ClassName("ui-search-layout__item"));
                foreach (var element in elements)
                {
                    var produto = new Produto();

                    produto.Name = element.FindElement(By.ClassName("ui-search-link__title-card")).GetAttribute("title");
                    produto.Price = element.FindElement(By.ClassName("andes-money-amount__fraction")).Text;
                    //produto.Freight = element.FindElement(By.ClassName("ui-pb-highlight")).Text;
                    produto.Link = element.FindElement(By.ClassName("ui-search-link")).GetAttribute("href");
                    produto.Photo = element.FindElement(By.ClassName("ui-search-result-image__element")).GetAttribute("src");

                    produtos.Add(produto);
                }

                if (util.Exist(driver, By.XPath(@"//*[@id='root-app']/div/div[3]/section/nav/ul/li[12]/a")))
                {
                    nextPage = driver.FindElement(By.XPath(@"//*[@id='root-app']/div/div[3]/section/nav/ul/li[12]/a")).GetAttribute("href");
                    driver.Navigate().GoToUrl(nextPage);
                    Thread.Sleep(2000);
                }
            }

            return produtos;
        }
    }
}
