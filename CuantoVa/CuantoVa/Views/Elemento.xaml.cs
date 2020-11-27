using System;
using SQLite;
using System.IO;
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
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;

        IEnumerable<Persona> ResultadoDelete;
        IEnumerable<Persona> ResultadoUpdate;
        public Elemento(int id)
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = id;
        }

        public static IEnumerable<Persona> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Persona>
                ("Update Persona Set nombre=?, usuario=?, contrasenia=? where id = ?", nombre, usuario, contrasenia, id);
        }

        public static IEnumerable<Persona> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Persona>("Delete From Persona where id = ?", id);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {


            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, contra.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se Actualizó correctamente", "ok");
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }
    }
}