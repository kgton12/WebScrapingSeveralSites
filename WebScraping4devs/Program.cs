using WebScraping4devs.Driver;
using WebScraping4devs.Enum;
using Utils;

class Program
{
    static void Main()
    {
        var web = new WebScraping();

        web.GetCPF("https://www.4devs.com.br/gerador_de_cpf",10, @"C:\Users\kgton\Desktop\cpf.csv");

        web.GetCardNumber("https://www.4devs.com.br/gerador_de_numero_cartao_credito", Flag.MasterCard, 10, @"C:\Users\kgton\Desktop\cartao.csv");

    }
}