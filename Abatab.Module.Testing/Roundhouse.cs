using System.Reflection;
using Abatab.Core.Catalog;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing
{
    public class Roundhouse
    {
        public static void ParseCommand(SessionProperties sessionProperties)
        {
            LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);

            switch (sessionProperties.RequestCommand)
            {
                case "datadump":
                    LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);
                    Action.DataDump.ParseAction(sessionProperties);
                    break;

                default:
                    LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Should probably put something here to help exit gracefully.
                    break;
            }

            LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
