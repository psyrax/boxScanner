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
    public partial class AddToBox : ContentPage
    {
        public AddToBox()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(Object sender, EventArgs e)
        {
            BoxItem boxItem = (BoxItem)BindingContext;
            await App.Database.SaveItemAsync(boxItem);
            _ = await Navigation.PopAsync();
        }
    }
}