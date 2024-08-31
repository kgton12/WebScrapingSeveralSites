# WebScrapingSeveralSites

Este repositório contém vários projetos de web scraping, cada um focado em diferentes sites e funcionalidades. Todos os projetos são desenvolvidos em C# e utilizam Selenium WebDriver para automação de navegação web.

## Estrutura do Repositório

- **Utils/**: Contém utilitários comuns usados por outros projetos.
  - [Util.cs](Utils/Util.cs)
  - [Utils.csproj](Utils/Utils.csproj)

- **Webscraper.io/**: Projeto de scraping para o site Webscraper.io.
  - [Program.cs](Webscraper.io/Program.cs)
  - [WebScrapingSelenium.csproj](Webscraper.io/WebScrapingSelenium.csproj)
  - [WebScrapingSelenium.sln](Webscraper.io/WebScrapingSelenium.sln)

- **WebScraping4devs/**: Projeto de scraping para o site 4devs.
  - [Program.cs](WebScraping4devs/Program.cs)
  - [WebScraping4devs.csproj](WebScraping4devs/WebScraping4devs.csproj)
  - [WebScraping4devs.sln](WebScraping4devs/WebScraping4devs.sln)

- **WebScrapingAmazon/**: Projeto de scraping para o site Amazon.
  - [Program.cs](WebScrapingAmazon/Program.cs)
  - [WebScrapingAmazon.csproj](WebScrapingAmazon/WebScrapingAmazon.csproj)

- **WebScrapingML/**: Projeto de scraping para o site Mercado Livre.
  - [Program.cs](WebScrapingML/Program.cs)
  - [WebScrapingML.csproj](WebScrapingML/WebScrapingML.csproj)
  - [Produto.cs](WebScrapingML/Model/Produto.cs)

- **WebScrapingShopee/**: Projeto de scraping para o site Shopee.
  - [WebScrapingShopee.csproj](WebScrapingShopee/WebScrapingShopee.csproj)
  - [Produto.cs](WebScrapingShopee/Model/Produto.cs)

- **WebScrapingZoom/**: Projeto de scraping para o site Zoom.
  - [Program.cs](WebScrapingZoom/Program.cs)
  - [WebScrapingZoom-BuscaPe.csproj](WebScrapingZoom/WebScrapingZoom-BuscaPe.csproj)

## Dependências

Cada projeto tem suas próprias dependências, mas a maioria utiliza:

- [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver/)
- [CsvHelper](https://www.nuget.org/packages/CsvHelper/)
- [Tesseract](https://www.nuget.org/packages/Tesseract/) (em alguns projetos)

## Como Executar

1. Clone o repositório:
    ```sh
    git clone https://github.com/seu-usuario/WebScrapingSeveralSites.git
    cd WebScrapingSeveralSites
    ```

2. Navegue até o diretório do projeto que deseja executar:
    ```sh
    cd WebScrapingML
    ```

3. Restaure as dependências e execute o projeto:
    ```sh
    dotnet restore
    dotnet run
    ```

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
