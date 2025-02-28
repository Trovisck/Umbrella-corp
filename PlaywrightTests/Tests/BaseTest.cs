using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    public class BaseTest
    {
        protected IPlaywright _playwright; // Instância global do Playwright
        protected IBrowser _browser;       // Instância do navegador
        protected IBrowserContext _context; // Contexto do navegador
        protected IPage _page;             // Página ativa no teste

        // Configuração antes de cada teste
        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync(); // Inicia o Playwright
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }); // Abre o navegador
            _context = await _browser.NewContextAsync(); // Cria um novo contexto
            _page = await _context.NewPageAsync(); // Abre uma nova página
        }

        // Finalização após cada teste
        [TearDown]
        public async Task Cleanup()
        {
            await _browser.CloseAsync(); // Fecha o navegador
            _playwright.Dispose(); // Metodo para liberar recursos
        }

    }
}
