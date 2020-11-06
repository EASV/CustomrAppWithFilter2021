using System;

namespace CustomerApp.Core.ApplicationService.Exceptions
{
    public class DataSourceException: Exception
    {
        public DataSourceException(string message): base(message) {}
    }
}