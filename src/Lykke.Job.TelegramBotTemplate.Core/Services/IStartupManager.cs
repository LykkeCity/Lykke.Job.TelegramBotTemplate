using System.Threading.Tasks;

namespace Lykke.Job.TelegramBotTemplate.Core.Services
{
    public interface IStartupManager
    {
        Task StartAsync();
    }
}