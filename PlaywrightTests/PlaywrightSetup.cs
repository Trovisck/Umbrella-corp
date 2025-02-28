using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    [SetUpFixture]
    public class PlaywrightSetup
    {
        public static IPlaywright PlaywrightInstance { get; private set; } = null!;
        public static IBrowser Browser { get; private set; } = null!;

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            PlaywrightInstance = await Playwright.CreateAsync();
            Browser = await PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Garante que o navegador será aberto
                SlowMo = 200, // Deixa a automação mais lenta para parecer mais humano
                Channel = "chrome" // Usa o Chrome real instalado no PC
            });
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            await Browser.CloseAsync();
            PlaywrightInstance.Dispose();
        }
    }
}
