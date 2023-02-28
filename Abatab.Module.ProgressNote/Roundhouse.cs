// Abatab.Module.ProgressNote.ParseRequest.cs
// b230224.1700
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.ProgressNote
{
    public class Roundhouse
    {
        public static void ParseCommand(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abSession.RequestCommand)
            {
                case "placeofservice":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    Action.PlaceOfService.ParseAction(abSession);

                    break;

                default:
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Exit gracefully.
                    break;
            }
        }
    }
}
