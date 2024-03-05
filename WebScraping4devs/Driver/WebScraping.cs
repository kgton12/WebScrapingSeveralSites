
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebScraping4devs.Enum;
using WebScraping4devs.Model;
using Utils;


namespace WebScraping4devs.Driver
{
    public class WebScraping
    {
        public WebScraping()
        {
            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                driver = new ChromeDriver(options);
            }
        }

        IWebDriver driver = null;
        public string GetCPF(string link, int qtd, string dir)
        {
            var util = new Util();

            driver.Navigate().GoToUrl(link);

            List<Cpf> cpfs = new List<Cpf>();

            for (int i = 0; i < qtd; i++)
            {
                var cpf = new Cpf();
                IWebElement generateButton = driver.FindElement(By.Id("bt_gerar_cpf"));
                generateButton.Click();
                Thread.Sleep(1000);
                
                cpf.cpf = driver.FindElement(By.Id("texto_cpf")).Text;

                cpfs.Add(cpf);
            }

            util.SaveToCsv(cpfs, dir);

            util.CloseDriver(driver);

            return "";
        }
        public string GetCardNumber(string link, Flag flag, int qtd, string dir)
        {
            string idCardNumber = null;
            var util = new Util();

            driver.Navigate().GoToUrl(link);
 
            switch (flag)
            {
                case Flag.MasterCard:
                    idCardNumber = "master";
                    break;
                case Flag.Visa:
                    idCardNumber = "visa16";
                    break;
                case Flag.AmericanExpress:
                    idCardNumber = "amex";
                    break;
                case Flag.Dinners:
                    idCardNumber = "diners";
                    break;
                case Flag.Discover:
                    idCardNumber = "discover";
                    break;
                case Flag.HiperCard:
                    idCardNumber = "hiper";
                    break;
                default:
                    idCardNumber = "master";
                    break;
            }
            List<CreditCard> creditCards = new List<CreditCard>();

            for (int i = 0; i < qtd; i++)
            {
                var creditCard = new CreditCard();
                IWebElement flagCard = driver.FindElement(By.Id(idCardNumber));
                flagCard.Click();

                Thread.Sleep(1000);

                creditCard.CardNumber = driver.FindElement(By.Id("cartao_numero")).Text;
                creditCard.ExpirationDate = driver.FindElement(By.Id("data_validade")).Text;
                creditCard.SecurityCode = driver.FindElement(By.Id("codigo_seguranca")).Text;

                creditCards.Add(creditCard);
            }           

            util.SaveToCsv(creditCards, dir);

            util.CloseDriver(driver);

            return "";
        }
    }
}
