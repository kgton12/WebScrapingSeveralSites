using OpenQA.Selenium;
using WebScrapingAmazon.Model;
using Utils;


namespace WebScrapingAmazon.Driver
{
    public class WebScraping
    {
        IWebDriver? driver = null;
        public WebScraping()
        {
            driver = new Util().InitDriver();
        }
        public string GetProduct(string link, string selectProduct, int qtdPages)
        {
            List<Product> produtos = new List<Product>();
            var util = new Util();

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

            Thread.Sleep(2000);

            string? nextPage = null;

            for (int i = 0; i < qtdPages; i++)
            {
                var elements = driver.FindElements(By.ClassName("puis-card-container"));
                foreach (var element in elements)
                {
                    var produto = new Product();

                    if (util.Exist(By.ClassName("a-size-base-plus"), element))
                    {
                        produto.Name = element.FindElement(By.ClassName("a-size-base-plus")).Text;
                    }

                    if (util.Exist(By.ClassName("a-price"), element))
                    {
                        produto.Price = CheckValue(element.FindElement(By.ClassName("a-price")).Text);
                    }

                    if (util.Exist(By.ClassName("a-link-normal"), element))
                    {
                        produto.Link = element.FindElement(By.ClassName("a-link-normal")).GetAttribute("href");
                    }

                    if (util.Exist(By.ClassName("s-image"), element))
                    {
                        produto.Photo = element.FindElement(By.ClassName("s-image")).GetAttribute("src");
                    }

                    produtos.Add(produto);
                }

                if (util.Exist(By.ClassName("s-pagination-next"), null, driver))
                {
                    nextPage = driver.FindElement(By.ClassName("s-pagination-next")).GetAttribute("href");
                    if (nextPage != null)
                    {
                        driver.Navigate().GoToUrl(nextPage);
                    }
                    Thread.Sleep(2000);
                }
            }

            util.SaveToCsv(produtos, @"C:\Users\kgton\Desktop\AZ.csv");

            return "";
        } 
        public string CheckValue(string value)
        {
            return value.Replace("\r\n", ",");
        }
    }
}
