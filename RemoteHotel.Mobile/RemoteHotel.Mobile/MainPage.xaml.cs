using CommonServiceLocator;
using RemoteHotel.Mobile.Interfaces;
using RemoteHotel.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RemoteHotel.Mobile
{
	public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public string DisplayName { get; } = "MY TEXT";
        public MainPage()
		{
            InitializeComponent();
            var a = DependencyService.Get<INfcImplementation>().EnableWriteMode();

            var viewModel = new NfcSpeachModel(a);

            BindingContext = viewModel;
        }
	}
}
