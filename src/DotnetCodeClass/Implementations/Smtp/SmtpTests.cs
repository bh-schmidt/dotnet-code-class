using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace DotnetCodeClass.Implementations.Smtp
{
    public class SmtpTests : BaseTests
    {
        [Test]
        public void SendMail()
        {
            var sendMailLocal = new SendMailLocal();
            var sendMailHost = new SendMailHost();
            
            var from = new MailAddress("from_test@test.com", "Test Account", Encoding.UTF8);
            var to = new MailAddress("to_test@gmail.com");

            var body = "I am just testing. . .";
            var bodyEncoding = Encoding.UTF8;

            var subject = "Just a test";
            var subjectEncoding = Encoding.UTF8;

            var userState = Guid.NewGuid();

            sendMailLocal.SendAsync(from, to, body, bodyEncoding, subject, subjectEncoding, userState, OnSendCompleted);
            sendMailHost.SendAsync(from, to, body, bodyEncoding, subject, subjectEncoding, userState, OnSendCompleted);

            Thread.Sleep(100000);
        }

        private void OnSendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.UserState != null)
            {
                Debug.WriteLine($"User event: {e.UserState}");
            }

            if (e.Cancelled)
            {
                Debug.WriteLine("Email sending was cancelled");
                return;
            }

            if (e.Error != null)
            {
                Debug.WriteLine("There was an error on sending the email.");
                return;
            }

            Debug.WriteLine("Email sended.");
        }
    }
}
