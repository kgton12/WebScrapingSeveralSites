
using WebScrapingEasyAutomation.Driver;

var web = new WebScraper();

var computers = web.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers");
var tablets = web.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers/tablets");
var laptops = web.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers/laptops");


 