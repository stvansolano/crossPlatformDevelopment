namespace CrossPlatformApp
{
    using System;
    using System.Collections.Generic;

    public partial class DictionaryBindingExample
    {
        public DictionaryBindingExample()
		{
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

            }

            var list = new Dictionary<string, string>() { 
                { "a", "1" },
                { "b", "2" },
                { "c", "3" },
                { "d", "4" },
                { "e", "5" },
                { "f", "6" },
            };
            listView.ItemsSource = list;
		}
    }
}