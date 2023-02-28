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

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    //Core.DataExport.SessionInformation.ToSessionRoot(abSession); // ALREADY DONE?

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    abSession.ReturnOptionObject.ToReturnOptionObject();
                    //abSession.ReturnOptionObject.ErrorCode = 1;
                    //abSession.ReturnOptionObject.ErrorMesg = "Hi!";

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    //Core.DataExport.SessionInformation.ToSessionRoot(abSession);

                    //LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

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