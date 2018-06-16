using Lykke.Job.TelegramBotTemplate.Settings.JobSettings;
using Lykke.Job.TelegramBotTemplate.Settings.SlackNotifications;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Job.TelegramBotTemplate.Settings
{
    public class AppSettings
    {
        public TelegramBotTemplateSettings TelegramBotTemplateJob { get; set; }

        public SlackNotificationsSettings SlackNotifications { get; set; }

        [Optional]
        public MonitoringServiceClientSettings MonitoringServiceClient { get; set; }
    }
}
