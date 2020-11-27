using System;
using SQLite;
using CuantoVa.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CuantoVa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroItem : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public RegistroItem()
        {
            InitializeComponent();
            this.conn = DependencyService.Get<Database>().GetConnection();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Item { Codbar = codBarras.Text, Cantidad = cantItem.Text, Descitem = descItem.Text , Precio = precItem.Text};
                conn.InsertAsync(DatosRegistro);
                limpiarFormulario();
                Navigation.PopAsync();
                DisplayAlert("Alerta", "Producto agregado", "ok");
                Navigation.PushAsync(new Itemlista());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alert", "Se agregó correctamente" + ex.Message, "ok");
            }

        }

        private void limpiarFormulario()
        {
            codBarras.Text = "";
            cantItem.Text = "";
            descItem.Text = "";
            precItem.Text = "";

        }
    }
}