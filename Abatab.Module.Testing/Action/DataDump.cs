// Abatab.Module.Testing.Action.DataDump.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

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
                case "sessioninformation":
                    LogEvent.Trace(sessionProperties, Assembly.GetExecutingAssembly().GetName().Name);



                    Core.DataExport.SessionInformation.ToSessionRoot(sessionProperties);


                    //Abatab.Core.DataExport.

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
