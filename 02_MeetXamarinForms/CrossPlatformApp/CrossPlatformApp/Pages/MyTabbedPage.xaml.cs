namespace CrossPlatformApp
{
	using Xamarin.Forms;
	using System.Collections.ObjectModel;

	public partial class MyTabbedPage : TabbedPage
	{
		public MyTabbedPage ()
		{
			InitializeComponent ();

			ItemsSource = new ObservableCollection<MonkeyDataModel>
            {
                new MonkeyDataModel
                {
                    Name = "Chimpanzee",
                    Family = "Hominidae",
                    Subfamily = "Homininae",
                    Tribe = "Panini",
                    Genus = "Pan",
                    PhotoUrl="http://upload.wikimedia.org/wikipedia/commons/thumb/6/62/Schimpanse_Zoo_Leipzig.jpg/640px-Schimpanse_Zoo_Leipzig.jpg"
                },
                new MonkeyDataModel
                {
                    Name = "Orangutan",
                    Family = "Hominidae",
                    Subfamily = "Ponginae",
                    Genus = "Pongo",
                    PhotoUrl="http://upload.wikimedia.org/wikipedia/commons/b/be/Orang_Utan%2C_Semenggok_Forest_Reserve%2C_Sarawak%2C_Borneo%2C_Malaysia.JPG"
                },
                new MonkeyDataModel
                {
                    Name = "Tamarin",
                    Family = "Callitrichidae",
                    Genus = "Saguinus",
                    PhotoUrl="http://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Tamarin_portrait_2_edit3.jpg/640px-Tamarin_portrait_2_edit3.jpg"
                }
            };
        }
	}

	public class MonkeyDataModel 
	{
		public string Name { get; set; }
		public string Family { get; set; }
		public string Subfamily { get; set; }
		public string Tribe { get; set; }
		public string Genus { get; set; }
		public string PhotoUrl { get; set; }
	}
}