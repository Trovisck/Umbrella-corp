using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MailKit;
using MimeKit;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PlaywrightTests.Utils
{
    public class EmailUtils
    {
        private const string Host = "imap.gmail.com";
        private const int Port = 993;
        private const string Username = "atendimento@grantoseguros.com";
        private const string Password = "EhfI*6~93sEk";

        public static async Task<string> GetVerificationCode()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    // 🔹 Ignorar validação SSL (evita erros de certificado)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    // Conectar ao IMAP com segurança
                    await client.ConnectAsync(Host, Port, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(Username, Password);

                    var inbox = client.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadOnly);

                    var uids = await inbox.SearchAsync(SearchQuery.SubjectContains("Código de Acesso - Umbrella Corporate"));

                    if (uids.Count == 0)
                    {
                        Console.WriteLine("Nenhum e-mail encontrado.");
                        return string.Empty;
                    }

                    var message = await inbox.GetMessageAsync(uids.Last());
                    string body = message.TextBody;

                    var match = System.Text.RegularExpressions.Regex.Match(body, @"\b\d{6}\b");

                    await client.DisconnectAsync(true);

                    return match.Success ? match.Value : string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar o e-mail: {ex.Message}");
                return string.Empty;
            }
        }
    }
}

