using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;

namespace examen1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagecontacto : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
       

        public byte[] GetimageBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    return fotobyte;
                }

            }

            return null;
        }






        public Pagecontacto()
        {
            InitializeComponent();
        }

        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {
            var contacto = new models.contacto
            {
                nombre = nombres.Text,
                telefono = telefonos.Text,
                edad = Edades.Text,
                pais = paise.SelectedItem.ToString(),
                nota = notas.Text,
                foto = GetimagesBytes()
            };

            if (photo != null)
            {
                if (await App.DataBase.addcontacto(contacto) > 0)
                {
                    await DisplayAlert("Aviso", "Estudiante ingresado con exito", "OK");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error..", "OK");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Favor tome una foto primero", "OK");
            }
        }

        private byte[] GetimagesBytes()
        {
            throw new NotImplementedException();
        }

        private async void btntomar_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {

                Directory = "APP",
                Name = "Foto.jpg",
                SaveToAlbum = true

            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
    }
}