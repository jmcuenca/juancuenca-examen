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
	public partial class Resumen : ContentPage
	{
        public Datos dt { get; set; }
		public Resumen (Datos dt)
		{
			InitializeComponent ();
            this.dt = dt;
            BindingContext = this;
        }
	}
}