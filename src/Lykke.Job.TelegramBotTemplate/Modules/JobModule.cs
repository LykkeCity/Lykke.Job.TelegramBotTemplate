using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Log;
using Lykke.Job.TelegramBotTemplate.Core.Services;
using Lykke.Job.TelegramBotTemplate.Settings.JobSettings;
using Lykke.Job.TelegramBotTemplate.Services;
using Lykke.SettingsReader;
using Lykke.Job.TelegramBotTemplate.TelegramBot;
using Common;

namespace Lykke.Job.TelegramBotTemplate.Modules
{
    public class JobModule : Module
    {
        private readonly TelegramBotTemplateSettings _settings;
        private readonly IReloadingManager<TelegramBotTemplateSettings> _settingsManager;
        private readonly ILog _log;
        // NOTE: you can remove it if you don't need to use IServiceCollection extensions to register service specific dependencies
        private readonly IServiceCollection _services;

        public JobModule(TelegramBotTemplateSettings settings, IReloadingManager<TelegramBotTemplateSettings> settingsManager, ILog log)
        {
            _settings = settings;
            _log = log;
            _settingsManager = settingsManager;
            _services = new ServiceCollection();
        }

        protected override void Load(ContainerBuilder builder)
        {
            // NOTE: Do not register entire settings in container, pass necessary settings to services which requires them
            // ex:
            // builder.RegisterType<QuotesPublisher>()
            //  .As<IQuotesPublisher>()
            //  .WithParameter(TypedParameter.From(_settings.Rabbit.ConnectionString))

            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            builder.RegisterType<TelegramBotService>()
                .As<IStartable>()
                .As<IStopable>()
                .WithParameter(TypedParameter.From(_settings.BotToken))
                .SingleInstance(); 

            // TODO: Add your dependencies here

            builder.Populate(_services);
        }
    }
}
