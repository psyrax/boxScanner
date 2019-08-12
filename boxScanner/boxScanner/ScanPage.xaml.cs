using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace boxScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ZXingScannerPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {

                var boxContent = new BoxContent();
                Box scannedBox = await App.Database.GetBoxAsync(result.Text);
                if (scannedBox == null)
                {
                    Box box = new Box
                    {
                        Name = result.Text,
                        BoxId = result.Text
                    };
                    await App.Database.SaveBoxAsync(box);
                    scannedBox = await App.Database.GetBoxAsync(result.Text);
                }


                boxContent.BindingContext = scannedBox;
                
                await Navigation.PushAsync(page: boxContent);
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            IsScanning = false;
            ScanPage scanPage = this;
            Navigation.RemovePage(scanPage);
        }
    }
}