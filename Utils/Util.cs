using CsvHelper;
using OpenQA.Selenium;
using System.Globalization;

namespace Utils
{
    public class Util
    {
        public bool Exist(By by, IWebElement element = null, IWebDriver driver = null)
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
    }
}
