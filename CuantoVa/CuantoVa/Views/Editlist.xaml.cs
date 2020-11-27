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
    public partial class Editlist : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;

        IEnumerable<Item> ResultadoDelete;
        IEnumerable<Item> ResultadoUpdate;
        public Editlist(int cod,string desc, string cant ,string prec)
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = cod;
            txtDesc.Text = desc;
            txtCant.Text = cant;
            txtPrec.Text = prec;

        }

        public static IEnumerable<Item> Update(SQLiteConnection db, string cantidad, string descitem, string precio, int cod)
        {
            return db.Query<Item>
                ("Update Item Set cantidad=?, descitem=?, precio=? where cod = ?", cantidad, descitem, precio, cod);
        }

        public static IEnumerable<Item> Delete(SQLiteConnection db, int cod)
        {
            return db.Query<Item>("Delete From Item where cod = ?", cod);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {


            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, txtDesc.Text, txtCant.Text, txtPrec.Text, IdSeleccionado);
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