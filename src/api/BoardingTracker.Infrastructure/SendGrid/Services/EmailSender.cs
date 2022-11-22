using BoardingTracker.Infrastructure.SendGrid.Constants;
using BoardingTracker.Infrastructure.SendGrid.Interfaces;
using BoardingTracker.Infrastructure.SendGrid.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BoardingTracker.Infrastructure.SendGrid.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;
        private readonly SendGridModel _sendGridModel;

        public EmailSender(ISendGridClient sendGridClient, SendGridModel sendGridModel)
        {
            _sendGridClient = sendGridClient;
            _sendGridModel = sendGridModel;
        }

        public async Task SendEmailAsync(List<string> emails)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridModel.FromEmail, _sendGridModel.FromName),
                Subject = SendGridConstants.Subject,
                PlainTextContent = SendGridConstants.Message
            };

            foreach (var email in emails)
            {
                msg.AddTo(new EmailAddress(email));
            }

            await _sendGridClient.SendEmailAsync(msg);
        }
    }
}
