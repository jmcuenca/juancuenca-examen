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
	public partial class Registro : ContentPage
	{
        public Datos dto { get; set; }

		public Registro (string usuario)
		{
			InitializeComponent ();
            dto = new Datos();
            BindingContext = this;
            this.dto.usuario = usuario;
		}
        public void btnCalcular_Clicked(object sender, EventArgs args) {


            if (this.txtNombre.Text == null) {
                DisplayAlert("Error", "Ingresa el nombre", "Error");
                return;
            }
            this.dto.nombre = this.txtNombre.Text;
            try
            {
                decimal cuotaI = 0;
                decimal.TryParse(txtCuotaInicial.Text, out cuotaI);
                if (cuotaI == 0 || cuotaI>=1800) {
                    DisplayAlert("Error", "Cuota inicial fuera de rango", "Error");
                    return;
                }
                
                decimal pendiente = 1800-cuotaI;

                decimal cuotamensual = pendiente / 3 + (1800) * 0.05M;
                this.dto.cuotam=decimal.Round(cuotamensual, 2, MidpointRounding.AwayFromZero);
                this.dto.total = this.dto.cuotai + this.dto.cuotam * 3;
                this.txtCuotaMensual.Text = this.dto.cuotam.ToString();

            }
            catch (Exception ex) {
                DisplayAlert("Error", "Ocurrio un error", "Error");


            }
        }
        public void btnResumen_Clicked(object sender, EventArgs args) {

            abrirVentanaAsync();
        }

        private async void abrirVentanaAsync()
        {
            Resumen resumen = new Resumen(this.dto);
            await this.Navigation.PushAsync(resumen);
        }
    }
}