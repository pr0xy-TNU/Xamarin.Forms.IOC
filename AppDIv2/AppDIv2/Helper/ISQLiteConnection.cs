using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLite.Net;

namespace AppDI.Helper
{
    public interface ISQLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
