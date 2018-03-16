using Microsoft.AspNet.Identity;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.IdentityServices.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            await configSendGridasync(message);
        }

        private async Task configSendGridasync(IdentityMessage message)
        {
            SendGridMessage myMessage = new SendGridMessage();

            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress("no-reply@siriuspm.com", "Sirius");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            NetworkCredential credential = new NetworkCredential(
                                                    ConfigurationManager.AppSettings["mailAccount"], 
                                                    ConfigurationManager.AppSettings["mailPassword"]);

            Web transportWeb = new Web(credential);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                //Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}
