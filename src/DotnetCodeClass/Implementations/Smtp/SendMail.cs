using System.Net;
using System.Net.Mail;
using System.Text;

namespace DotnetCodeClass.Implementations.Smtp
{
    public abstract class SendMail
    {
        public void SendAsync(MailAddress from,
            MailAddress to,
            string body,
            Encoding bodyEncoding,
            string subject,
            Encoding subjectEncoding,
            object userState = null,
            SendCompletedEventHandler onSendCompleted = default)
        {
            var message = new MailMessage(from, to);

            message.Body = body;
            message.BodyEncoding = bodyEncoding;

            message.Subject = subject;
            message.SubjectEncoding = subjectEncoding;

            SendAsync(message, userState, onSendCompleted);
        }

        public abstract void SendAsync(MailMessage message, object userToken = null, SendCompletedEventHandler onSendCompleted = default);
    }
}
