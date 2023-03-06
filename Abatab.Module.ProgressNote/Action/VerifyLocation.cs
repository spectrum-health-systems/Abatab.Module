// Abatab.Module.ProgressNote.Action.VerifyLocation.cs
// b---------x
// Copyright (c) A Pretty Cool Program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using Abatab.Core.Utilities;

namespace Abatab.Module.ProgressNote.Action
{
    public class VerifyLocation
    {
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            var serviceChargeCodeValue = abSession.SentOptionObject.GetFieldValue("51001");
            var locationValue          = abSession.SentOptionObject.GetFieldValue("50004");

            switch (abSession.RequestAction)
            {
                case "groupindinote":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    if (ValidGroupIndividualizedNote(abSession.ModProgressNote.ServiceChargeCodesCheck, serviceChargeCodeValue, abSession.ModProgressNote.ValidLocations, locationValue))
                    {
                        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
                        abSession.ReturnOptionObject.ToReturnOptionObject();
                    }
                    else
                    {
                        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                        Create(abSession, serviceChargeCodeValue);
                    }
                    //VerifyForGroupIndividualizedNote(abSession);

                    break;

                case "indicounselingnote":
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);


                    if (ValidIndividualCounselingNote(abSession.ModProgressNote.ServiceChargeCodePrefixes, serviceChargeCodeValue, abSession.ModProgressNote.ValidLocations, locationValue))
                    {
                        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                        abSession.ReturnOptionObject.ToReturnOptionObject();
                    }
                    else
                    {
                        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
                        Create(abSession, serviceChargeCodeValue);
                    }

                    //VerifyForIndividualCouncelingNote(abSession);

                    break;

                default:
                    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

                    // TODO - Exit gracefully.

                    break;
            }
        }

        //public static void test(AbSession abSession)
        //{
        //    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

        //    var serviceChargeCodeValue = abSession.SentOptionObject.GetFieldValue("51001");
        //    var locationValue          = abSession.SentOptionObject.GetFieldValue("50004");

        //    var testThing = false;

        //    if (abSession.RequestAction == "groupindinote")
        //    {
        //        testThing = TestGroup(abSession.ModProgressNote.ServiceChargeCodesCheck, serviceChargeCodeValue, abSession.ModProgressNote.ValidLocations, locationValue);
        //    }




        //}

        private static bool ValidGroupIndividualizedNote(List<string> serviceChargeCodesCheck, string serviceChargeCodeValue, List<string> validLocations, string locationValue)
        {
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

            if (serviceChargeCodesCheck.Contains(serviceChargeCodeValue) && (validLocations.Contains(locationValue)))
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
                return true;
            }
            else
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
                return false;
            }
        }


        private static bool ValidIndividualCounselingNote(List<string> serviceChargeCodePrefixes, string serviceChargeCodeValue, List<string> validLocations, string locationValue)
        {
            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

            if (serviceChargeCodePrefixes.Any(codePrefix => serviceChargeCodeValue.StartsWith(codePrefix)) && (validLocations.Contains(locationValue)))
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
                return true;
            }
            else
            {
                Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
                return false;
            }
        }

        private static void Create(AbSession abSession, string serviceChargeCodeValue)
        {
            LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

            Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}");

            //abSession.ReturnOptionObject.SetFieldValue("50004", "");
            abSession.ReturnOptionObject.ErrorCode = 1;
            abSession.ReturnOptionObject.ErrorMesg = $"WARNING!{Environment.NewLine}" +
                                                   $"{Environment.NewLine}" +
                                                   $"Service Charge Code {serviceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
                                                   $"  - T110{Environment.NewLine}" +
                                                   $"  - second" +
                                                   $"{Environment.NewLine}" +
                                                   $"Please verify you have the correct location.";

            //abSession.ReturnOptionObject.ToReturnOptionObject();
        }




        //public static void VerifyForGroupIndividualizedNote(AbSession abSession)
        //{
        //    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

        //    var serviceChargeCodeValue = abSession.SentOptionObject.GetFieldValue("51001");
        //    var locationValue          = abSession.SentOptionObject.GetFieldValue("50004");

        //    Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

        //    if (abSession.ModProgressNote.ServiceChargeCodesCheck.Contains(serviceChargeCodeValue) && (!abSession.ModProgressNote.ValidLocations.Contains(locationValue)))
        //    {
        //        LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

        //        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

        //        abSession.ReturnOptionObject.SetFieldValue("50004", "");
        //        abSession.ReturnOptionObject.ErrorCode = 1;
        //        abSession.ReturnOptionObject.ErrorMesg = $"WARNING!{Environment.NewLine}" +
        //                                               $"{Environment.NewLine}" +
        //                                               $"1Service Charge Code {serviceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
        //                                               $"  - T110{Environment.NewLine}" +
        //                                               $"  - second" +
        //                                               $"{Environment.NewLine}" +
        //                                               $"Please verify you have the correct location.";
        //    }
        //    else
        //    {
        //        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
        //        abSession.ReturnOptionObject.ToReturnOptionObject();
        //    }
        //}

        //public static void VerifyForIndividualCouncelingNote(AbSession abSession)
        //{
        //    LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

        //    var serviceChargeCodeValue = abSession.SentOptionObject.GetFieldValue("51001");
        //    var locationValue          = abSession.SentOptionObject.GetFieldValue("50004");

        //    Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

        //    if (abSession.ModProgressNote.ServiceChargeCodePrefixes.Any(codePrefix => serviceChargeCodeValue.StartsWith(codePrefix)) && (!abSession.ModProgressNote.ValidLocations.Contains(locationValue)))
        //    {
        //        LogEvent.Trace(abSession, Assembly.GetExecutingAssembly().GetName().Name);

        //        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");

        //        abSession.ReturnOptionObject.SetFieldValue("50004", "");
        //        abSession.ReturnOptionObject.ErrorCode = 1;
        //        abSession.ReturnOptionObject.ErrorMesg = $"WARNING!{Environment.NewLine}" +
        //                                               $"{Environment.NewLine}" +
        //                                               $"2Service Charge Code {serviceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
        //                                               $"  - T110{Environment.NewLine}" +
        //                                               $"  - second" +
        //                                               $"{Environment.NewLine}" +
        //                                               $"Please verify you have the correct location.";
        //    }
        //    else
        //    {
        //        Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name, $"{serviceChargeCodeValue}-{locationValue}");
        //        abSession.ReturnOptionObject.ToReturnOptionObject();
        //    }
        //}





    }
}
