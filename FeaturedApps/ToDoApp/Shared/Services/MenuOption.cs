namespace Shared.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Windows.Input;

    public class Menu
    {
        public string Title { get; set; }
        public IEnumerable<MenuOption> Options { get; set; }

        public string CancelText { get; set; }

        public string DestructionText { get; set; }
    }

    public class MenuOption
    {
        public ICommand Command { get; set; }
        public string Text { get; set; }
    }
}