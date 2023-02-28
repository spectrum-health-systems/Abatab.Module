using System;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using Abatab.Core.Utilities;

namespace Abatab.Module.ProgressNote.Action
{
    public class PlaceOfService
    {
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abSession.RequestAction)
            {
                case "verifytelehealthloc":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    DoTheWork(abSession);

                    break;

                default:
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    // TODO - Exit gracefully.

                    break;
            }
        }

        public static void DoTheWork(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            var serviceChargeCodeValue = abSession.SentOptionObject.GetFieldValue("51001");
            var locationValue = abSession.SentOptionObject.GetFieldValue("50004");

            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

            if (abSession.ModProgressNote.ServiceChargeCodesCheck.Contains(serviceChargeCodeValue) && (!abSession.ModProgressNote.ValidLocations.Contains(locationValue)))
            {
                LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

                abSession.ReturnOptionObject.SetFieldValue("50004", "");
                abSession.ReturnOptionObject.ErrorCode = 1;
                abSession.ReturnOptionObject.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                       $"{Environment.NewLine}" +
                                                       $"Service Charge Code {serviceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
                                                       $"  - T110{Environment.NewLine}" +
                                                       $"  - second" +
                                                       $"{Environment.NewLine}" +
                                                       $"Please verify you have the correct location.";
            }
            else
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
                //abSession.ReturnOptionObject.ToReturnOptionObject();
            }
        }
    }
}