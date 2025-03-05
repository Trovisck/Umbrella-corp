using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PlaywrightTests.Pages
{
    // Classe que representa a página de login
    public class LoginPage
    {
        private readonly IPage _page; // Página do Playwright que será usada
        private readonly string _url = "https://corp-dev.salmonwave-bd510ac6.brazilsouth.azurecontainerapps.io/login";

        // Construtor da classe LoginPage, recebe a página como parâmetro
        public LoginPage(IPage page) => _page = page;

        // 🔹 Localizadores da página
        private ILocator EmailInput => _page.Locator("input[placeholder='Ex: seuemail@mail.com']");
        private ILocator SubmitButton => _page.Locator("button.sc-FEMpB.dWMZZG");
        private ILocator CodeInputs => _page.Locator("input[type='text']"); // Seletor para os campos do código
        private ILocator PageTitle => _page.Locator("h1"); // Seletor para validar o login bem-sucedido

        // 🔹 Método para acessar a página de login
        public async Task NavigateAsync() => await _page.GotoAsync(_url);

        // 🔹 Método para preencher o campo de e-mail
        public async Task FillEmailAsync(string email) => await EmailInput.FillAsync(email);

        // 🔹 Método para clicar no botão de envio
        public async Task ClickSubmitAsync() => await SubmitButton.ClickAsync();

        // 🔹 Método para preencher o código de verificação
        public async Task FillVerificationCodeAsync(string code)
        {
            var inputs = await _page.QuerySelectorAllAsync("input[type='text']");

            if (inputs.Count != 6)
            {
                throw new Exception("❌ Não foram encontrados 6 campos de input para o código!");
            }

            for (int i = 0; i < code.Length; i++)
            {
                await inputs[i].FillAsync(code[i].ToString());
                await _page.WaitForTimeoutAsync(200); // Pequeno delay para evitar falhas
            }
        }

        // 🔹 Método para validar se o login foi bem-sucedido
        public async Task<bool> IsLoginSuccessful()
        {
            string title = await PageTitle.InnerTextAsync();
            return title == "Emissão de apólices"; // Verifica se o título da página está correto
        }

        // 🔹 Método para capturar um screenshot
        public async Task TakeScreenshotAsync(string path) => await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path });

       // 🔹 Localizador para a mensagem de erro quando o token é inválido
        private ILocator ErrorMessage => _page.Locator("p.sc-gjXmFk.gRolOp");

              // 🔹 Método para verificar se a mensagem de erro aparece
           public async Task<bool> IsErrorMessageDisplayed()
               {
                   return await ErrorMessage.IsVisibleAsync();
               }

              // 🔹 Método para obter o texto exato da mensagem de erro
           public async Task<string> GetErrorMessageText()
               {
                   return await ErrorMessage.InnerTextAsync();
               }
}

}
