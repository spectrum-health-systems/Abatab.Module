// Abatab.Module.Testing.Roundhouse.cs
// b230225.1749
// Copyright (c) A Pretty Cool Program

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing
{
    public static class Roundhouse2
    {
        public static void ParseCommand(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abSession.RequestCommand)
            {
                case "datadump":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    Action.DataDump.ParseAction(abSession);
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    break;

                default:
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // TODO - Exit gracefully.
                    break;
            }
        }
    }
}