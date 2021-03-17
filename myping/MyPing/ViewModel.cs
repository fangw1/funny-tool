using System;
using System.ComponentModel;
using System.Globalization;

namespace MyPing
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		[NonSerialized]
		private PropertyChangedEventHandler propertyChanged;

		public event PropertyChangedEventHandler PropertyChanged
		{
			add { propertyChanged += value; }
			remove { propertyChanged -= value; }
		}

		protected void RaisePropertyChanged(string propertyName)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (propertyChanged != null) { propertyChanged(this, e); }
		}

		private void CheckPropertyName(string propertyName)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(this)[propertyName];
			if (propertyDescriptor == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
					"The property with the propertyName '{0}' doesn't exist.", propertyName));
			}
		}
	}
}
