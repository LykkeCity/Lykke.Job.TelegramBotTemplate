using System.Threading.Tasks;

namespace Lykke.Job.TelegramBotTemplate.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}
