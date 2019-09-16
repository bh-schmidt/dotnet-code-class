using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;

namespace DotnetCodeClass.Implementations.Smtp
{
    public class SendMailLocal : SendMail
    {
        private const string EmailHolderPath = @"C:\temp\mails";
        
        public override void SendAsync(MailMessage message, object userToken = null, SendCompletedEventHandler onSendCompleted = default)
        {
            var client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            client.PickupDirectoryLocation = EmailHolderPath;
            client.SendCompleted += onSendCompleted;
            client.SendAsync(message, userToken);
        }
    }
}
