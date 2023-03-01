// Abatab.Module.ProgressNote.Roundhouse.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.ProgressNote
{
    /// <summary>Summary goes here.</summary>
    public static class Roundhouse
    {
        /// <summary>Summary goes here.</summary>
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