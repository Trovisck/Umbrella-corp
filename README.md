# 🚀 Projeto de Automação com Playwright e C#

Este é um projeto de automação de testes utilizando **Playwright** com **C#** e **NUnit**. Ele realiza testes automatizados em aplicações web, incluindo login e verificação de elementos.

---

## 📌 **Pré-requisitos**
Antes de começar, certifique-se de que seu ambiente está configurado corretamente:

### 🛠 **Instale os seguintes itens:**
1. **[.NET SDK 9.0+](https://dotnet.microsoft.com/en-us/download)**
2. **[Git](https://git-scm.com/downloads)**
3. **[Node.js](https://nodejs.org/) (opcional, para comandos Playwright CLI)**
4. **Editor de Código**: Recomendo o **Visual Studio** ou **JetBrains Rider**.

---

## 📌 **Clonando o repositório**
Execute o comando abaixo para baixar o projeto:
```sh
git clone https://github.com/Trovisk/Umbrella-corp.git
cd Umbrella-corp/PlaywrightTests
```
---

## 📌 **Instalando dependências**
Após clonar o projeto, instale as dependências necessárias:
```sh
dotnet restore
```
Caso os navegadores do Playwright não estejam instalados, rode:
```sh
playwright install
```
---

## 📌 **Configurando o projeto**
Certifique-se de que o arquivo `playwright.config.cs` contém as configurações desejadas, como **modo headless**, **timeouts** e **navegadores**.

Se quiser rodar os testes **com interface gráfica (sem headless)**, altere no `PlaywrightSetup.cs`:
```c#
var launchOptions = new BrowserTypeLaunchOptions
{
Headless = false, // Definir como false para ver a execução dos testes
SlowMo = 100 // Adiciona um pequeno delay para facilitar a visualização
};
```
---

## 📌 **Rodando os testes**
### 🔹 **Executar todos os testes**
```sh
dotnet test
```
### 🔹 **Executar um teste específico**
```sh
dotnet test --filter TesteLogin
```
### 🔹 **Rodar testes no modo debug**
```sh
dotnet test --configuration Debug
```
---

## 📌 **Estrutura do Projeto**
📂 **PlaywrightTests** (Pasta principal do projeto)  
┣ 📂 **Tests** → Contém os testes automatizados  
┃ ┣ 📄 `LoginTest.cs` → Teste de login na aplicação  
┣ 📂 **Pages** → Implementação do Page Object Model (POM)  
┃ ┣ 📄 `LoginPage.cs` → Contém métodos para interagir com a página de login  
┣ 📂 **bin** → Pasta gerada após compilação  
┣ 📂 **obj** → Arquivos temporários do build  
┣ 📄 `PlaywrightTests.csproj` → Arquivo de configuração do projeto .NET  
┣ 📄 `playwright.config.cs` → Configuração global do Playwright  
┗ 📄 `README.md` → Documentação do projeto

---

## 📌 **Screenshots e Logs**
Caso os testes falhem, os screenshots são armazenados automaticamente em:

PlaywrightTests/bin/Debug/net9.0/screenshots/

Verifique essa pasta para entender possíveis falhas no teste.

---

## 📌 **Dicas e Solução de Problemas**
1️⃣ **Erro: `playwright install` não funciona**  
Execute:
```sh
dotnet tool install --global Microsoft.Playwright.CLI
playwright install
```
2️⃣ **Erro: `PlaywrightTests.csproj` não encontrado**  
Certifique-se de que está rodando os comandos dentro da pasta `PlaywrightTests`.

3️⃣ **Erro de permissão ao rodar `playwright.ps1` no Windows**  
No terminal, rode o comando:
```sh
Set-ExecutionPolicy RemoteSigned -Scope Process
```
4️⃣ **Erros de compatibilidade com .NET SDK**  
Atualize seu .NET para a versão 9.0+.

---

## 📌 **Contribuindo**
Caso queira contribuir, siga os passos:

1. Faça um **fork** do repositório.
2. Crie um **branch**:
```sh
git checkout -b minha-feature
```
3. Faça o **commit**:
```sh
git commit -m "Minha nova feature"
```
4. Envie para o repositório:
```sh
git push origin minha-feature
```
5. Abra um **Pull Request**!

---

## 📌 **Contato**
Caso tenha dúvidas ou sugestões, entre em contato:  
📧 **holanda.victor@grantoseguros.com**  
📌 Desenvolvido por **Victor Holanda**
