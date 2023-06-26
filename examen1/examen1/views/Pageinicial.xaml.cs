using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace examen1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pageinicial : ContentPage
    {
        public Pageinicial()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listecontactos.ItemsSource = await App.DataBase.obtenerlistacontacto();
           
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pegecont = new views.Pagecontacto();
            Navigation.PushAsync(pegecont);

        }
    }


}