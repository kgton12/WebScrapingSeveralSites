using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using Tesseract;

namespace Utils
{
    public class Util
    {
        public bool Exist(By by, IWebElement? element = null, IWebDriver? driver = null)
        {
            if (driver != null)
            {
                return driver.FindElements(by).Any();
            }
            else if (element != null)
            {
                return element.FindElements(by).Any();
            }
            else { return false; }
        }
        public void CloseDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }
        }
        public void SaveToCsv<T>(IEnumerable<T> obj, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<T>();
                csv.NextRecord();

                foreach (var item in obj)
                {
                    csv.WriteRecord(item);
                    csv.NextRecord();
                }
            }
        }
        public IWebDriver InitDriver()
        {
            IWebDriver driver = null;

            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();
                //options.AddArgument("--headless");
                options.AddArgument(@"--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.159 Safari/537.36");
                driver = new ChromeDriver(options);
                //driver = new ChromeDriver();
            }

            return driver;

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
    }
}
