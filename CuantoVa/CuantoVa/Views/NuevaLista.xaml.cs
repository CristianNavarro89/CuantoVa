using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuantoVa.Models;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CuantoVa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaLista : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public NuevaLista()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private async void btnGo_Clicked(object sender, EventArgs e)
        {

            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Item>();
                await Navigation.PushAsync(new Itemlista());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "Ok");
            }
            

        }
    }
}