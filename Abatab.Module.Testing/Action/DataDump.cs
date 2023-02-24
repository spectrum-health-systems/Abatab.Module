using System.Reflection;
using Abatab.Core.Catalog;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing.Action
{
    internal class DataDump
    {
        public static void ParseAction(SessionProperties sessionProperties)
        {
            LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);

            switch (sessionProperties.RequestAction)
            {
                case "sessiondetails":
                    LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);




                    //LogEvent.SessionDetails(sessionDetail);
                    //? session.FinalOptionObject = session.SentOptionObject.ToReturnOptionObject();
                    //? AbatabOptionObject.FinalObj.Finalize(sessionDetail);
                    //DataDump.SessionData(session);

                    break;

                default:
                    LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Exit gracefully.
                    break;
            }
        }
    }
}
