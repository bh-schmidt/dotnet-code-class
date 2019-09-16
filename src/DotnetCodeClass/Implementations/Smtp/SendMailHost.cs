using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DotnetCodeClass.Implementations.Smtp
{
    class SendMailHost : SendMail
    {
        private const string Host = "smtp.gmail.com";
        private const int Port = 587;
        private const string CredentialUserName = "";
        private const string CredentialPassowrd = "";

        public override void SendAsync(MailMessage message, object userToken = null, SendCompletedEventHandler onSendCompleted = default)
        {
            var client = new SmtpClient(Host, Port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(CredentialUserName, CredentialPassowrd);
            client.EnableSsl = true;
            client.SendCompleted += onSendCompleted;
            client.SendAsync(message, userToken);
        }
    }
}
