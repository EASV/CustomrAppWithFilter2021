using System;

namespace CustomerApp.Core.Exceptions
{
    public class DataSourceException: Exception
    {
        public DataSourceException(string message): base(message) {}
    }
}