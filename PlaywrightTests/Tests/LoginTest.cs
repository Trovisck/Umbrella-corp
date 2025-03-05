using NUnit.Framework;
using PlaywrightTests.Pages;
using PlaywrightTests.Utils; // Importa a classe para capturar o e-mail
using System;
using System.Threading.Tasks;

namespace PlaywrightTests.Tests
{
    public class LoginTest : BaseTest
    {
        private LoginPage _loginPage; // Página de Login

        [SetUp]
        public void SetupTest()
        {
            Console.WriteLine("🔹 Iniciando LoginTest...");
            _loginPage = new LoginPage(_page);
        }

        [Test]
        public async Task TesteLoginComVerificacao()
        {
            Console.WriteLine("🔹 Acessando a página de login...");
            await _loginPage.NavigateAsync();

            Console.WriteLine("🔹 Preenchendo e enviando o e-mail...");
            await _loginPage.FillEmailAsync("atendimento@grantoseguros.com");
            await _loginPage.ClickSubmitAsync();

            Console.WriteLine("🔹 Aguardando chegada do e-mail...");
            await _page.WaitForTimeoutAsync(5000);

            Console.WriteLine("🔹 Buscando o código de verificação...");
            string token = await EmailUtils.GetVerificationCode();
            Console.WriteLine($"🔹 Token Capturado: {token}");

            Assert.That(token, Is.Not.Null.And.Not.Empty, "❌ O código de verificação não foi encontrado!");

            Console.WriteLine("🔹 Inserindo o código de verificação...");
            await _loginPage.FillVerificationCodeAsync(token);

            Console.WriteLine("🔹 Aguardando processamento...");
            await _page.WaitForTimeoutAsync(3000);

            Console.WriteLine("🔹 Capturando screenshot...");
            await _loginPage.TakeScreenshotAsync("screenshots/login_post_verification.png");

            Console.WriteLine("🔹 Validando se o login foi bem-sucedido...");
            bool loginSuccessful = await _loginPage.IsLoginSuccessful();
            Assert.That(loginSuccessful, Is.True, "❌ O login falhou!");

            Console.WriteLine("✅ Teste concluído com sucesso!");
        }

        [Test]
        public async Task TesteTokenInvalido()
        {
            Console.WriteLine("🔹 Acessando a página de login...");
            await _loginPage.NavigateAsync();

            Console.WriteLine("🔹 Preenchendo e enviando o e-mail...");
            await _loginPage.FillEmailAsync("atendimento@grantoseguros.com");
            await _loginPage.ClickSubmitAsync();

            Console.WriteLine("🔹 Aguardando a página de código de verificação...");
            await _page.WaitForTimeoutAsync(3000);

            Console.WriteLine("🔹 Inserindo um código inválido...");
            string invalidToken = "000000"; // Código inválido fixo
            await _loginPage.FillVerificationCodeAsync(invalidToken);

            Console.WriteLine("🔹 Aguardando mensagem de erro...");
            await _page.WaitForTimeoutAsync(2000);

            Console.WriteLine("🔹 Validando se a mensagem de erro foi exibida...");
            bool isErrorDisplayed = await _loginPage.IsErrorMessageDisplayed();
            Assert.That(isErrorDisplayed, Is.True, "❌ A mensagem de erro não foi exibida!");

            string errorMessage = await _loginPage.GetErrorMessageText();
            Console.WriteLine($"🔹 Mensagem exibida: {errorMessage}");

            Assert.That(errorMessage, Is.EqualTo("Token expirado ou inválido, tente novamente"),
                "❌ A mensagem de erro exibida está incorreta!");

            Console.WriteLine("✅ Teste de token inválido concluído com sucesso!");
        }

    }
  }
