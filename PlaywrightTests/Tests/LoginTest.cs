using NUnit.Framework;
using PlaywrightTests.Pages;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    public class LoginTest : BaseTest  // 🟢 HERDA a configuração de BaseTest
    {
        private LoginPage _loginPage; // Página de Login

        [SetUp]
        public void SetupTest() // Removido 'async'
        {
            _loginPage = new LoginPage(_page);
        }

        [Test]
        public async Task TesteEnvioToken()
        {
            // 1️⃣ Acessa a página de login
            await _loginPage.NavigateAsync();

            // 2️⃣ Preenche o campo de e-mail
            await _loginPage.FillEmailAsync("holanda.victor@grantoseguros.com");

            // 3️⃣ Aguarda antes de clicar
            await _page.WaitForTimeoutAsync(1000);

            // 4️⃣ Clica no botão de envio
            await _loginPage.ClickSubmitAsync();

            // 5️⃣ Aguarda o processamento
            await _page.WaitForTimeoutAsync(3000);

            // 6️⃣ Captura um screenshot
            await _loginPage.TakeScreenshotAsync("screenshots/login_post_click.png");
        }
    }
}
