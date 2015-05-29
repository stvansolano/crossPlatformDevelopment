namespace Shared.Infrastructure.Services
{
    using System.Threading.Tasks;

    public interface IMessageService
    {
        Task<MenuOption> PickChoiceFrom(Menu menu);
        Task<bool> ShowYesNo(string title, string message, string acceptMessage, string cancelMessage);
    }
}