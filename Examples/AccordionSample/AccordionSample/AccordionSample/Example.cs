namespace AccordionSample
{
    using Xamarin.Forms;

    public class AccordionViewExample : ContentPage
    {
        public AccordionViewExample()
        {
            var accordion = new AccordionView();
            accordion.Items.Add(new AccordionItem { Title = "Item #1", Content = "Body content #1", IsSelected = true });
            accordion.Items.Add(new AccordionItem { Title = "Item #2", Content = "Body content #2" });
            accordion.Items.Add(new AccordionItem { Title = "Item #3", Content = "Body content #3" });

            Content = accordion;
        }
    }
}