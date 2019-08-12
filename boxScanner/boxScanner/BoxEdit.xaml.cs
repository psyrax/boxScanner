using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace boxScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxEdit : ContentPage
    {
        public BoxEdit()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(Object sender, EventArgs e) {
            Box box = (Box)BindingContext;
            await App.Database.SaveBoxAsync(box);
            _ = await Navigation.PopAsync();
        }
    }
}