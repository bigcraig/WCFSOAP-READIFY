using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(Namespace="http://craigwoollett.com/servicesV1")]
   // [ServiceBehavior]
    public class CraigService : ICraig
    {
        public long fibonacci(long value)
        {

            
            long a = 0;
            long b = 1;
            try
            {
                if (value > 94) 
                {throw new FaultException<ArgumentOutOfRangeException>( new ArgumentOutOfRangeException("value"," greater than FIB(94) will cause 64bit integer overflow"), new FaultReason("FIB(94) or greater will cause 64bit intge overflow"));
                }
                    // In N steps compute Fibonacci sequence iteratively.
                for (int i = 0; i < value; i++)
                {
                    long temp = a;
                    a = b;
                    b = checked(temp + b);
                }
                return b;
            }
            catch(ArgumentOutOfRangeException e)
            {

                ArgumentOutOfRangeFault fault = new ArgumentOutOfRangeFault();
                fault.Result = false;
                fault.Message = " FIb(92)> will result in a 64bit integer overflow, sorry your story is too large";
                fault.Description = " FIb(92)> will result in a 64bit integer overflow, sorry your story is too large";
                
                // now throw fault exception to be transmitted to client
               // throw new FaultException<ArgumentOutOfRangeFault>(fault);
                throw new FaultException<ArgumentOutOfRangeException>(e);
            }
        }

        public Guid  WhatIsYourToken()
    {
      //  Guid  myGuid = / Create a GUID with all zeros and compare it to Empty.
      Byte[] bytes = new Byte[16];
      Guid myguid = new Guid(bytes);
      Guid myGuid = new Guid("c1170302-8e4e-4aca-bb3b-07f8936a0458");
      return myGuid;
    }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new FaultException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
