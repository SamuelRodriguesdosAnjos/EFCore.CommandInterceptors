using System.Data.Common;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCore.Interceptors
{
    //IDbCommandInterceptor
    public class InterceptorCommands: DbCommandInterceptor
    {
        private static readonly Regex _tableRegex = 
            new Regex(@"(?<tableAlias>FROM +(\[.*\]\.)?(\[.*\]) AS (\[.*\])(?! WITH \(NOLOCK\)))",
                RegexOptions.Multiline | 
                RegexOptions.IgnoreCase | 
                RegexOptions.Compiled);

        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command, 
            CommandEventData eventData, 
            InterceptionResult<DbDataReader> result)
        {

            UseNoLock(command);

            return base.ReaderExecuting(command, eventData, result);
        }

        private static void UseNoLock(DbCommand command)
        {
            if (!command.CommandText.Contains("WITH (NOLOCK)"))
            {
                command.CommandText = _tableRegex.Replace(command.CommandText, "${tableAlias} WITH (NOLOCK)");
            }
        }
    }
}