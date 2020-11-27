using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using SQLite;
using System.IO;
using CuantoVa.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]
namespace CuantoVa.iOS
{
    public class SqliteClient :  Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}