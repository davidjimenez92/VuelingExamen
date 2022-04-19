using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace VuelingExamen.Distributed.WebServices.Errors
{
    public class GlobalErrorHandler : IErrorHandler
    {
        private static readonly ILog _log = log4net.LogManager.
          GetLogger(System.Reflection.MethodBase.
          GetCurrentMethod().DeclaringType);

        public bool HandleError(Exception error)
        {
            _log.Error(string.Format(@"Exception caught at Service Application 
                                GlobalErrorHandler{0}Method: {1}{2}Message: {3}",
                 Environment.NewLine, error.TargetSite.Name,
                 Environment.NewLine, error.Message));
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var newEx = new FaultException(
               string.Format(@"Exception caught at Service Application 
                                GlobalErrorHandler{0}Method: {1}{2}Message: {3}",
               Environment.NewLine, error.TargetSite.Name,
               Environment.NewLine, error.Message));

            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
        }
    }
}