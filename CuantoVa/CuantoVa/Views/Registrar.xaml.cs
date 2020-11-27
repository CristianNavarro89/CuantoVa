using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CuantoVa.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CuantoVa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {

        private SQLiteAsyncConnection conn;
        public Registrar()
        {
            InitializeComponent();
            this.conn = DependencyService.Get<Database>().GetConnection();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Persona { Nombre = nombre.Text, Usuario = usuario.Text, Contrasenia = contra.Text };
                conn.InsertAsync(DatosRegistro);
                limpiarFormulario();
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                DisplayAlert("Alert", "Se agregó correctamente" + ex.Message, "ok");
            }

        }

        private void limpiarFormulario()
        {
            nombre.Text = "";
            usuario.Text = "";
            contra.Text = "";


        }
    }
}