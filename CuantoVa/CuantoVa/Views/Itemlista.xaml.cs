using System;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Itemlista : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Item> _TablaItem;
       

        public Itemlista()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            
        }
        protected async override void OnAppearing()
        {
            var resultadoRegistros = await _conn.Table<Item>().ToListAsync();
            _TablaItem = new ObservableCollection<Item>(resultadoRegistros);
            ListaItem.ItemsSource = _TablaItem;
            base.OnAppearing();
            
        }

        private void ListaItem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Item)e.SelectedItem;
            var item = Obj.Cod.ToString();
            int COD = Convert.ToInt32(item);

            var cant = Obj.Cantidad.ToString();
            var prec = Obj.Precio.ToString();
            var desc = Obj.Descitem.ToString();


            try
            {
                Navigation.PushAsync(new Editlist(COD,desc,cant,prec));
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BarScan());
        }

       }
}
