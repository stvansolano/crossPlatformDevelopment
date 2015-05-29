namespace CrossPlatformApp.Pages
{
    using Shared.Infrastructure.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class MessageService : IMessageService
    {
        private readonly Page _page;

        public MessageService(Page page)
        {
            _page = page;
        }

        public Task<MenuOption> PickChoiceFrom(Menu menu)
        {
            var actionSheet = _page.DisplayActionSheet(menu.Title, menu.CancelText, menu.DestructionText, menu.Options.Select(item => item.Text).ToArray());

            return actionSheet.ContinueWith<MenuOption>(task => menu.Options.FirstOrDefault(item => item.Text == task.Result));
        }

        public Task<bool> ShowYesNo(string title, string message, string acceptMessage, string cancelMessaage)
        {
            return _page.DisplayAlert(title, message, acceptMessage, cancelMessaage);
        }
    }
}