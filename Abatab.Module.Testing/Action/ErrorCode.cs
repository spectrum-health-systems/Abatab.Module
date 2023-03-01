// Abatab.Module.Testing.Action.ErrorMessage.cs
// b---------x
// Copyright (c) A Pretty Cool Program


using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing.Action
{
    /// <summary>Summary goes here.</summary>
    public class ErrorCode
    {
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abSession.RequestAction)
            {
                case "errorcode1":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    abSession.ReturnOptionObject.SetFieldValue("50004", "T102");
                    abSession.ReturnOptionObject.SetFieldValue("10750", "TEST 230301.1147");

                    abSession.ReturnOptionObject.ToReturnOptionObject(4, "Testing Error Code 1");

                    //abSession.ReturnOptionObject.ErrorCode = 1;
                    //abSession.ReturnOptionObject.ErrorMesg = "Testing: Error Code 1";

                    break;

                default:

                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    // TODO - Exit gracefully.
                    break;
            }
        }

    }
}
