using System.IO;
using AppDI.Helper;
using AppDIv2.Droid;
using AppDIv2.Helper;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQL))]
namespace AppDIv2.Droid
{
    class AndroidSQL : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string databasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbFullPath = Path.Combine(databasePath, DataBaseHelper.DATABASE_NAME);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var androidConnection = new SQLiteConnection(platform, dbFullPath);
            return androidConnection;
        }
    }
}