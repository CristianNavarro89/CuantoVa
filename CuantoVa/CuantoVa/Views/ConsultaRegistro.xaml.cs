using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CuantoVa.Models;

namespace CuantoVa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Persona> _TablaPersona;
        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }
        protected async override void OnAppearing()
        {
            var resultadoRegistros = await _conn.Table<Persona>().ToListAsync();
            _TablaPersona = new ObservableCollection<Persona>(resultadoRegistros);
            ListaUsuario.ItemsSource = _TablaPersona;
            base.OnAppearing();
        }

        private void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Persona)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}