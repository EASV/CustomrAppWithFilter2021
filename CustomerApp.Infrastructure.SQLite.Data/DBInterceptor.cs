using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CustomerApp.Infrastructure.SQLite.Data
{
    public class DBInterceptor :DbCommandInterceptor
    {
        public override DbDataReader ReaderExecuted( DbCommand command, CommandExecutedEventData eventData, DbDataReader result) 
        {
            //do something
            return result;
        }
    }
}