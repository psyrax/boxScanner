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
    public partial class BoxContent : ContentPage
    {
        
        public BoxContent()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Box box = (Box)BindingContext;
            BindingContext = await App.Database.GetBoxAsync(box.BoxId);
            listView.ItemsSource = await App.Database.GetItemsAsync(box.BoxId);
        }
        async void EditboxInfo(object sender, EventArgs e)
        {
            Box box = (Box)BindingContext;
            var boxEdit = new BoxEdit
            {
                BindingContext = box
            };
            await Navigation.PushAsync(page: boxEdit);
        }
        async void AddToBox(object sender, EventArgs e)
        {
            Box box = (Box)BindingContext;
            BoxItem boxItem = new BoxItem
            {
                BoxId = box.BoxId
            };
            var addBox = new AddToBox
            {
               BindingContext = boxItem
            };
            await Navigation.PushAsync(page: addBox);
        }


        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AddToBox
                {
                    BindingContext = e.SelectedItem as BoxItem
                });
            }
        }
    }
}