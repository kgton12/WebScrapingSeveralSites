using WebScrapingAmazon.Driver;

var web = new WebScraping();

web.GetProduct("https://www.amazon.com.br/", "Pneu", 10);
