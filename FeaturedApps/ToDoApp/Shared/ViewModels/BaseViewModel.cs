namespace Shared.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;

	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		private string subTitle = string.Empty;
		/// <summary>
		/// Gets or sets the "Subtitle" property
		/// </summary>
		public const string SubtitlePropertyName = "Subtitle";
		public string Subtitle
		{
			get { return subTitle; }
			set { SetProperty(ref subTitle, value, SubtitlePropertyName); }
		}

		protected void SetProperty<U>(
			ref U backingStore, U value,
			string propertyName,
			Action onChanged = null,
			Action<U> onChanging = null)
		{
			if (EqualityComparer<U>.Default.Equals(backingStore, value))
				return;

			if (onChanging != null)
				onChanging(value);

			backingStore = value;

			if (onChanged != null)
				onChanged();

			OnPropertyChanged(propertyName);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}