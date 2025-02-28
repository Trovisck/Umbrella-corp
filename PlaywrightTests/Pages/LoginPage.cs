using Microsoft.Playwright;
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

        // Localizador para o campo de e-mail (usa placeholder como referência)
        private ILocator EmailInput => _page.Locator("input[placeholder='Ex: seuemail@mail.com']");

        // Localizador para o botão de envio
        private ILocator SubmitButton => _page.Locator("button.sc-FEMpB.dWMZZG");

        // Metodo para navegar até a página de login
        public async Task NavigateAsync() => await _page.GotoAsync(_url);

        // Metodo para preencher o campo de e-mail
        public async Task FillEmailAsync(string email) => await EmailInput.FillAsync(email);

        // Metodo para clicar no botão de envio
        public async Task ClickSubmitAsync() => await SubmitButton.ClickAsync();

        // Metodo para capturar uma screenshot e salvar na pasta screenshots/
        public async Task TakeScreenshotAsync(string path) => await _page.ScreenshotAsync(new PageScreenshotOptions { Path = path });
    }
}
