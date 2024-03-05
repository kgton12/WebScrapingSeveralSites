using CsvHelper;
using OpenQA.Selenium;
using System.Globalization;

namespace Utils
{
    public class Util
    {
        public bool Exist(IWebDriver driver, By elemento)
        {
            return driver.FindElements(elemento).Any();
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
