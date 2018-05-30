using System;
using System.Collections.Generic;
using System.Text;

namespace AppDIv2.Helper
{
    public class DBUtils
    {
        public const string DATABASE_NAME = "app_di.db";
        public const string DATABASE_VERSION = "1.0";
        public class Tables
        {
            public const string USERS_TABLE = "users";
            public const string ID = "id";
            public const string USER_FIRST_NAME = "first_name";
            public const string USER_LAST_NAME = "last_name";
            public const string USER_EMAIL = "email";
            public const string USER_AGE = "age";
            public const string USER_PHONE_NUMBER = "phone";
        }

    }
}
