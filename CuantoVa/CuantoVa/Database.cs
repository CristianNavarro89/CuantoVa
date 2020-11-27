using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CuantoVa
{
   public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
