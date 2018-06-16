using Lykke.Job.TelegramBotTemplate.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace Lykke.Job.TelegramBotTemplate.Services
{
    public class BotService : IBotService
    {
        public TelegramBotClient Client { get; }
    }
}
