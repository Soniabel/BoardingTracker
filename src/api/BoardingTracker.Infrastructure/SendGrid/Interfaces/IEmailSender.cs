namespace BoardingTracker.Infrastructure.SendGrid.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(List<string> emails);
    }
}
