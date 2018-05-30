using AppDIv2.Helper;
using SQLite.Net.Attributes;

namespace AppDI.Models
{
    [Table(DBUtils.Tables.USERS_TABLE)]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column(DBUtils.Tables.USER_FIRST_NAME)]
        public string FirstName { get; set; }

        [Column(DBUtils.Tables.USER_LAST_NAME)]
        public string LastName { get; set; }

        [Column(DBUtils.Tables.USER_EMAIL)]
        public string UserEmail { get; set; }

        [Column(DBUtils.Tables.USER_AGE)]
        public int Age { get; set; }

        [Column(DBUtils.Tables.USER_PHONE_NUMBER)]
        public string PhoneNumber { get; set; }

    }
}
