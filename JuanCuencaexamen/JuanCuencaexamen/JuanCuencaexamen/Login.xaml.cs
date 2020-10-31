using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JuanCuencaexamen
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}
        public void btnIngresar_Clicked(object sender, EventArgs arg)
        {
            if (txtClave.Text == null || txtUsuario.Text.Length ==0) {
                DisplayAlert("Error", "Ingresa el usuario", "Error");
                return;
            }
            if (txtClave.Text ==null || txtClave.Text.Length == 0)
            {
                DisplayAlert("Error", "Ingresa la clave", "Error");
                return;
            }

            if (txtClave.Text.Equals("uisrael2020") && txtUsuario.Text.Equals("estudiante2020"))
            {
                abrirVentanaAsync(txtUsuario.Text);

            }
            else
            {
                DisplayAlert("Error", "Usuario o clave incorrecta", "Error");
                this.txtClave.Text = "";
                this.txtUsuario.Text = "";
            }
        }
        private async void abrirVentanaAsync(string usuario)
        {
            Registro ejercicio = new Registro(usuario);
            await this.Navigation.PushAsync(ejercicio);
        }

    }
}