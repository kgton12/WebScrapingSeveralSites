using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebScrapingAmazon.Model;
using Tesseract;
using Utils;


namespace WebScrapingAmazon.Driver
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
                options.AddArgument(@"--user-agent=(Windows NT 10.0; Win64; x64) Chrome/92.0.4515.159");
                driver = new ChromeDriver(options);
                //driver = new ChromeDriver();
            }
        }
        public string GetProduct(string link, string selectProduct, int qtdPages)
        {
            List<Product> produtos = new List<Product>();
            var util = new Util();

            //string layout = null;
            Console.WriteLine("Iniciando");
            driver.Navigate().GoToUrl(link);
            Thread.Sleep(2000);


            /* string tessDataPath = @"C:\Program Files\Tesseract-OCR\tessdata";

             // Caminho para a imagem que você deseja processar
             string imagePath = @"C:\Users\kgton\Downloads\Captcha_wxfssuqrms.jpg";

             // Realiza o OCR na imagem
             string textFromImage = DoOCR(tessDataPath, imagePath);

             // Exibe o texto extraído
             Console.WriteLine("Texto extraído da imagem:");
             Console.WriteLine(textFromImage);*/




            IWebElement inputElement = driver.FindElement(By.Id("twotabsearchtextbox"));

            inputElement.SendKeys(selectProduct);

            inputElement.SendKeys(Keys.Enter);

            /*WebElement search = driver.FindElement(By.Id("nav-search-submit-button"));
            search.Click();*/
            Thread.Sleep(2000);



            string nextPage = null;
            string PriceAux = null;

            for (int i = 0; i < qtdPages; i++)
            {
                var elements = driver.FindElements(By.ClassName("puis-card-container"));
                foreach (var element in elements)
                {
                    var produto = new Product();
                    PriceAux = "";


                    if (util.Exist(driver, By.ClassName("a-size-base-plus")))
                    {
                        produto.Name = element.FindElement(By.ClassName("a-size-base-plus")).Text;
                    }

                    if (util.Exist(driver, By.ClassName("a-price")))
                    {
                        produto.Price = CheckValue(element.FindElement(By.ClassName("a-price")).Text);
                    }

                    if (util.Exist(driver, By.ClassName("a-link-normal")))
                    {
                        produto.Link = element.FindElement(By.ClassName("a-link-normal")).GetAttribute("href");
                    }

                    if (util.Exist(driver, By.ClassName("s-image")))
                    {
                        produto.Photo = element.FindElement(By.ClassName("s-image")).GetAttribute("src");
                    }               

                    produtos.Add(produto);
                }

                if (util.Exist(driver, By.ClassName("s-pagination-next")))
                {
                    nextPage = driver.FindElement(By.ClassName("s-pagination-next")).GetAttribute("href");
                    driver.Navigate().GoToUrl(nextPage);
                    Thread.Sleep(2000);
                }
            }

            util.SaveToCsv(produtos, @"C:\Users\kgton\Desktop\AZ.csv");

            return "";
        }
        static string DoOCR(string tessDataPath, string imagePath)
        {
            using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        return page.GetText();
                    }
                }
            }
        }
        public List<Product> GetProductPages(int qtdPages)
        {
            return null;
        }
        public string CheckValue(string value)
        {
            return value.Replace("\r\n", ",");
        }
    }
}
