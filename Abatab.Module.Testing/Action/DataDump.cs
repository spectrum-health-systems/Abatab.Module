// Abatab.Module.Testing.Action.DataDump.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing.Action
{
    internal class DataDump
    {
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abSession.RequestAction)
            {
                case "sessioninformation":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    Core.DataExport.SessionInformation.ToSessionRoot(abSession);
                    abSession.ReturnOptionObject.SetFieldValue("50004", "T102");
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    Core.DataExport.SessionInformation.ToSessionRoot(abSession);
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    //Abatab.Core.DataExport.

                    //LogEvent.SessionDetails(sessionDetail);
                    //? session.FinalOptionObject = session.SentOptionObject.ToReturnOptionObject();
                    //? AbatabOptionObject.FinalObj.Finalize(sessionDetail);
                    //DataDump.SessionData(session);

                    break;

                default:
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Exit gracefully.
                    break;
            }
        }
    }
}